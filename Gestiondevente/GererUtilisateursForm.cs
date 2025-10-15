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
using System.Security.Cryptography; // For password hashing

namespace Gestiondevente
{
    public partial class GererUtilisateursForm : Form
    {
        // Connection string to your database
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        // Variable pour stocker l'ID de l'utilisateur actuellement sélectionné pour la modification
        private int currentSelectedUserId = -1;

        public GererUtilisateursForm()
        {
            InitializeComponent();
            ChargerUtilisateurs();
            // Assurez-vous d'attacher le gestionnaire d'événements CellContentClick ici
            dgvListeUtilisateur.CellContentClick += dgvListeUtilisateur_CellContentClick;
        }

        private void GererUtilisateursForm_Load(object sender, EventArgs e)
        {
            // Le constructeur appelle déjà ChargerUtilisateurs(), donc cette méthode peut rester vide.
        }

        private void ChargerUtilisateurs()
        {
            // Cette méthode charge tous les utilisateurs dans le DataGridView.
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_utilisateur, nom, prenom, email, phone, role FROM Utilisateur";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvListeUtilisateur.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des utilisateurs : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // ---

        // Événements des boutons de la grille

        private void dgvListeUtilisateur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifie que le clic est dans une ligne de données valide et sur une colonne de bouton.
            if (e.RowIndex >= 0 && (dgvListeUtilisateur.Columns[e.ColumnIndex].Name == "btnModifierColumn" || dgvListeUtilisateur.Columns[e.ColumnIndex].Name == "btnSupprimerColumn"))
            {
                DataGridViewRow row = dgvListeUtilisateur.Rows[e.RowIndex];
                currentSelectedUserId = Convert.ToInt32(row.Cells["Id_utilisateur"].Value);

                // Gère le clic sur le bouton "Modifier"
                if (dgvListeUtilisateur.Columns[e.ColumnIndex].Name == "btnModifierColumn")
                {
                    // Remplit les champs de saisie avec les informations de l'utilisateur sélectionné.
                    txtNomutil.Text = row.Cells["nom"].Value.ToString();
                    txtPrenomutil.Text = row.Cells["prenom"].Value.ToString();
                    txtEmailutil.Text = row.Cells["email"].Value.ToString();
                    txtPhone.Text = row.Cells["phone"].Value.ToString();
                    // Pour le rôle, vous pourriez utiliser un ComboBox. Ici, on met le texte dans une zone de texte si nécessaire.
                    // Par exemple, txtRole.Text = row.Cells["role"].Value.ToString();
                    
                    MessageBox.Show("Veuillez modifier les informations dans les champs et cliquer sur le bouton 'Mise à jour'.", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Gère le clic sur le bouton "Supprimer"
                else if (dgvListeUtilisateur.Columns[e.ColumnIndex].Name == "btnSupprimerColumn")
                {
                    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection cnx = new SqlConnection(ConnectionString))
                            {
                                string query = "DELETE FROM Utilisateur WHERE Id_utilisateur = @id";
                                SqlCommand cmd = new SqlCommand(query, cnx);
                                cmd.Parameters.AddWithValue("@id", currentSelectedUserId);
                                cnx.Open();
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Utilisateur supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ChargerUtilisateurs(); // Recharge la liste
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur lors de la suppression de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // ---

        // Méthodes de gestion de l'interface

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Ce bouton peut être désactivé si vous utilisez les boutons de la grille
            // ou modifié pour gérer la suppression de la ligne sélectionnée dans la grille.
            if (dgvListeUtilisateur.SelectedRows.Count > 0)
            {
                // Utilise la même logique que le bouton "Supprimer" de la grille
                int idUtilisateur = (int)dgvListeUtilisateur.SelectedRows[0].Cells["Id_utilisateur"].Value;
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection cnx = new SqlConnection(ConnectionString))
                        {
                            string query = "DELETE FROM Utilisateur WHERE Id_utilisateur = @id";
                            SqlCommand cmd = new SqlCommand(query, cnx);
                            cmd.Parameters.AddWithValue("@id", idUtilisateur);
                            cnx.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Utilisateur supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerUtilisateurs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouterAdmin_Click(object sender, EventArgs e)
        {
            // Cette méthode ajoute un nouvel utilisateur avec le rôle "admin".
            if (string.IsNullOrEmpty(txtNomutil.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Veuillez entrer au moins un nom et un mot de passe pour le nouvel administrateur.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmemdp.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur de mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password before saving
            string hashedPassword = GetHashString(txtPassword.Text);

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO Utilisateur (nom, prenom, email, phone, mot_de_passe, role) VALUES (@nom, @prenom, @email, @phone, @mot_de_passe, @role)";
                    SqlCommand cmd = new SqlCommand(query, cnx);

                    cmd.Parameters.AddWithValue("@nom", txtNomutil.Text);
                    cmd.Parameters.AddWithValue("@prenom", txtPrenomutil.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmailutil.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@mot_de_passe", hashedPassword);
                    cmd.Parameters.AddWithValue("@role", "admin"); // Explicitly sets the role to 'admin'

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Nouvel administrateur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the textboxes after adding the admin
                    ClearInputFields();
                    ChargerUtilisateurs(); // Refresh the list to show the new admin
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'administrateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMiseAJour_Click(object sender, EventArgs e)
        {
            // Logique de mise à jour pour l'utilisateur sélectionné.
            if (currentSelectedUserId == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner un utilisateur à modifier dans le tableau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNomutil.Text) || string.IsNullOrEmpty(txtPrenomutil.Text))
            {
                MessageBox.Show("Le nom et le prénom de l'utilisateur ne peuvent pas être vides.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    // La requête de mise à jour.
                    string query = "UPDATE Utilisateur SET nom = @nom, prenom = @prenom, email = @email, phone = @phone, role = @role WHERE Id_utilisateur = @id";
                    SqlCommand cmd = new SqlCommand(query, cnx);

                    cmd.Parameters.AddWithValue("@nom", txtNomutil.Text);
                    cmd.Parameters.AddWithValue("@prenom", txtPrenomutil.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmailutil.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@role", "admin"); // Assurez-vous d'avoir un moyen de choisir le rôle, sinon, c'est codé en dur.
                    cmd.Parameters.AddWithValue("@id", currentSelectedUserId);

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Utilisateur mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    ChargerUtilisateurs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtNomutil.Clear();
            txtPrenomutil.Clear();
            txtEmailutil.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtConfirmemdp.Clear();
            currentSelectedUserId = -1; // Réinitialise l'ID sélectionné après la mise à jour.
        }

        // ---

        // Méthode de hachage de mot de passe

        // The password hashing method (reused from your login form)
        private string GetHashString(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
        
        // ---

        // Événements de l'interface utilisateur (laissés vides ou à compléter)

        private void txtNomutil_TextChanged(object sender, EventArgs e) { }
        private void txtPrenomutil_TextChanged(object sender, EventArgs e) { }
        private void txtEmailutil_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void txtConfirmemdp_TextChanged(object sender, EventArgs e) { }

        private void btnMiseAjour_Click_1(object sender, EventArgs e)
        {
            // Logique de mise à jour pour l'utilisateur sélectionné.
            if (currentSelectedUserId == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner un utilisateur à modifier dans le tableau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNomutil.Text) || string.IsNullOrEmpty(txtPrenomutil.Text))
            {
                MessageBox.Show("Le nom et le prénom de l'utilisateur ne peuvent pas être vides.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    // La requête de mise à jour.
                    string query = "UPDATE Utilisateur SET nom = @nom, prenom = @prenom, email = @email, phone = @phone, role = @role WHERE Id_utilisateur = @id";
                    SqlCommand cmd = new SqlCommand(query, cnx);

                    cmd.Parameters.AddWithValue("@nom", txtNomutil.Text);
                    cmd.Parameters.AddWithValue("@prenom", txtPrenomutil.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmailutil.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@role", "admin"); // Assurez-vous d'avoir un moyen de choisir le rôle, sinon, c'est codé en dur.
                    cmd.Parameters.AddWithValue("@id", currentSelectedUserId);

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Utilisateur mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    ChargerUtilisateurs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}