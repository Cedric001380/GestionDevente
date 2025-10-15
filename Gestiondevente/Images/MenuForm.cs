using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;

namespace Gestiondevente
{
    public partial class MenuForm : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";
        private int idUtilisateurConnecte;

        public MenuForm(int utilisateurId)
        {
            InitializeComponent();
            idUtilisateurConnecte = utilisateurId;
            this.pbPhotoProfil.Resize += new EventHandler(pbPhotoProfil_Resize);
            SetPictureBoxRound();
            ChargerPhotoProfil();
            ChargerTotaux();
        }

        public MenuForm()
        {
            InitializeComponent();
            idUtilisateurConnecte = -1;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
        }

        private void SetPictureBoxRound()
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, pbPhotoProfil.Width, pbPhotoProfil.Height);
            pbPhotoProfil.Region = new Region(gp);
        }

        private void pbPhotoProfil_Resize(object sender, EventArgs e)
        {
            SetPictureBoxRound();
        }

        private void ChargerPhotoProfil()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT image_utilisateur FROM Utilisateur WHERE Id_utilisateur = @idUser";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                        cnx.Open();
                        object imageData = cmd.ExecuteScalar();

                        if (imageData != DBNull.Value && imageData != null)
                        {
                            byte[] imageBytes = (byte[])imageData;
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pbPhotoProfil.Image = Image.FromStream(ms);
                                pbPhotoProfil.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                        else
                        {
                            pbPhotoProfil.Image = pbPhotoProfil.ErrorImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la photo de profil : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerTotaux()
        {
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                try
                {
                    cnx.Open();

                    SqlCommand cmdPlats = new SqlCommand("SELECT COUNT(*) FROM Plat", cnx);
                    int totalPlats = (int)cmdPlats.ExecuteScalar();
                    lblTotalPlats.Text = totalPlats.ToString();

                    SqlCommand cmdCommandes = new SqlCommand("SELECT COUNT(*) FROM Commande WHERE Id_utilisateur = @idUser", cnx);
                    cmdCommandes.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                    int totalCommandes = (int)cmdCommandes.ExecuteScalar();
                    lblTotalCommandes.Text = totalCommandes.ToString();

                    SqlCommand cmdTables = new SqlCommand("SELECT COUNT(*) FROM Banc", cnx);
                    int totalTables = (int)cmdTables.ExecuteScalar();
                    lblTotalTables.Text = totalTables.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des totaux : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ChargerTotaux();
        }

        private void btnPlat_Click(object sender, EventArgs e)
        {
            PlatAffichageForm platForm = new PlatAffichageForm();
            platForm.Show();
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            MainAffichageForm commandeForm = new MainAffichageForm(idUtilisateurConnecte);
            commandeForm.Show();
        }

        private void btnVoirCommande_Click(object sender, EventArgs e)
        {
            if (idUtilisateurConnecte == -1)
            {
                MessageBox.Show("Aucun utilisateur connecté. Veuillez vous reconnecter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VoirCommandeForm voirCommandeForm = new VoirCommandeForm(idUtilisateurConnecte);
            voirCommandeForm.Show();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            TableAffichage afficherTable = new TableAffichage();
            afficherTable.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment vous déconnecter ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnModifierImageutilisateur_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers image|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tous les fichiers|*.*";
            openFileDialog.Title = "Sélectionner une image pour votre profil";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    MettreAJourImageUtilisateur(imageBytes);
                    ChargerPhotoProfil();
                    MessageBox.Show("L'image de profil a été mise à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de la mise à jour de l'image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MettreAJourImageUtilisateur(byte[] imageBytes)
        {
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Utilisateur SET image_utilisateur = @image WHERE Id_utilisateur = @idUser";
                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    cmd.Parameters.AddWithValue("@image", imageBytes);
                    cmd.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erreur lors de la mise à jour de la base de données.", ex);
                    }
                }
            }
        }

        private void panelPlats_Paint(object sender, PaintEventArgs e) { }
        private void panelCommandes_Paint(object sender, PaintEventArgs e) { }
        private void panelTables_Paint(object sender, EventArgs e) { }
        private void lblTotalPlats_Click(object sender, EventArgs e) { }
        private void lblTotalCommandes_Click(object sender, EventArgs e) { }
        private void lblTotalTables_Click(object sender, EventArgs e) { }
        private void pbPhotoProfil_Click(object sender, EventArgs e) { }
        private void pbPhotoProfil_Paint(object sender, PaintEventArgs e) { }
        private void btnPaiment_Click(object sender, EventArgs e)
        {
            PaiementUtilisateur paiementForm = new PaiementUtilisateur();
            paiementForm.Show();
        }
    }
}