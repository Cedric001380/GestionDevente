using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography; // Pour le hachage du mot de passe
using System.Runtime.InteropServices; // Pour les coins arrondis si nécessaire

namespace Gestiondevente
{
    public partial class Connecter : Form
    {
        // On établit la connexion à la base de données.
        // Assurez-vous que le chemin d'accès au fichier .mdf est correct.
        SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True");

        public Connecter()
        {
            InitializeComponent();
        }

        private void Connecter_Load(object sender, EventArgs e)
        {
            // Peut être laissé vide ou utilisé pour le chargement initial si besoin.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Contrôle des champs de saisie
            if (string.IsNullOrEmpty(txtEmailouphone.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Veuillez entrer votre email/téléphone et votre mot de passe.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hachage du mot de passe saisi pour la comparaison
            // Assurez-vous que le mot de passe est stocké haché dans la base de données.
            string hashedPassword = GetHashString(txtPassword.Text);

            try
            {
                // 3. Préparation de la requête pour vérifier l'utilisateur ET récupérer son rôle
                string query = "SELECT role FROM Utilisateur WHERE (email = @login OR phone = @login) AND mot_de_passe = @password";

                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    // Utilisation de paramètres pour éviter les injections SQL
                    cmd.Parameters.AddWithValue("@login", txtEmailouphone.Text);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    cnx.Open();
                    object result = cmd.ExecuteScalar(); // Récupère la valeur de la colonne 'role'

                    // 4. Vérification du résultat et redirection
                    if (result != null)
                    {
                        string userRole = result.ToString();
                        MessageBox.Show("Connexion réussie ! Bienvenue.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        if (userRole.ToLower() == "admin")
                        {
                            MenuFormAdmin menuAdminForm = new MenuFormAdmin();
                            menuAdminForm.Show();
                        }
                        else if (userRole.ToLower() == "utilisateur")
                        {
                            MenuForm menuForm = new MenuForm();
                            menuForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Votre rôle n'est pas reconnu. Veuillez contacter l'administrateur.", "Erreur de rôle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show(); // Affiche à nouveau le formulaire de login si le rôle n'est pas bon
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email/téléphone ou mot de passe incorrect. Veuillez réessayer.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 5. Fermeture de la connexion
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        // Méthode de hachage SHA-256 (doit être la même que pour l'inscription)
        private string GetHashString(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Vous pouvez ajouter du code ici pour ouvrir un formulaire d'inscription.
            // Par exemple : InscriptionForm inscriptionForm = new InscriptionForm();
            // inscriptionForm.Show();
            // this.Hide();
        }

        private void txtEmailouphone_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
    }
}