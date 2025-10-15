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
using System.IO;
using System.Drawing.Drawing2D;

namespace Gestiondevente
{
    public partial class PlatAdminForm : Form
    {
        // La chaîne de connexion à la base de données.
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        // Variable pour stocker les données binaires de l'image
        private byte[] imageBytes = null;
        private int currentSelectedPlatId = -1; // Pour suivre l'ID du plat sélectionné

        public PlatAdminForm()
        {
            InitializeComponent();
            // Lier l'événement CellContentClick, qui est l'événement correct pour les boutons de colonne.
            dgvPlat.CellContentClick += new DataGridViewCellEventHandler(dgvPlat_CellContentClick);

            // Définit le mode de taille de l'image pour qu'elle s'étire ou se réduise pour s'adapter au PictureBox.
            pbImagePlat.SizeMode = PictureBoxSizeMode.StretchImage;
            // Ajoute une bordure simple pour rendre le cadre du PictureBox plus visible.
            pbImagePlat.BorderStyle = BorderStyle.FixedSingle;

            // ⭐ Rendre le pictureBoxLogo rond ⭐
            if (pictureBoxLogo != null)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, pictureBoxLogo.Width - 1, pictureBoxLogo.Height - 1);
                pictureBoxLogo.Region = new Region(path);
            }
        }

        private void PlatAdminForm_Load(object sender, EventArgs e)
        {
            ChargerPlats();
        }

        private void ChargerPlats()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_plat, nom, prix, category, description, image_plat FROM Plat";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPlat.DataSource = dt;

                    if (dgvPlat.Columns.Contains("image_plat"))
                    {
                        dgvPlat.Columns["image_plat"].Visible = false;
                    }
                    if (dgvPlat.Columns.Contains("Id_plat"))
                    {
                        dgvPlat.Columns["Id_plat"].Visible = false;
                    }

                    dgvPlat.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des plats : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtNomPlat.Clear();
            txtPrixPlat.Clear();
            cbbCategorie.SelectedIndex = -1;
            txtDescription.Clear();
            pbImagePlat.Image = null;
            imageBytes = null;
            currentSelectedPlatId = -1;
        }

        private void dgvPlat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPlat.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow row = dgvPlat.Rows[e.RowIndex];
                currentSelectedPlatId = Convert.ToInt32(row.Cells["Id_plat"].Value);

                if (dgvPlat.Columns[e.ColumnIndex].Name == "btnSupprimerColumn")
                {
                    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce plat ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection cnx = new SqlConnection(ConnectionString))
                            {
                                string query = "DELETE FROM Plat WHERE Id_plat = @idPlat";
                                using (SqlCommand cmd = new SqlCommand(query, cnx))
                                {
                                    cmd.Parameters.AddWithValue("@idPlat", currentSelectedPlatId);
                                    cnx.Open();
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Plat supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Aucun plat n'a été supprimé.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            ChargerPlats();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur lors de la suppression du plat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (dgvPlat.Columns[e.ColumnIndex].Name == "btnModifierColumn")
                {
                    txtNomPlat.Text = row.Cells["nom"].Value.ToString();
                    txtPrixPlat.Text = row.Cells["prix"].Value.ToString();
                    cbbCategorie.SelectedItem = row.Cells["category"].Value.ToString();
                    txtDescription.Text = row.Cells["description"].Value.ToString();

                    if (row.Cells["image_plat"].Value != DBNull.Value)
                    {
                        imageBytes = (byte[])row.Cells["image_plat"].Value;
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbImagePlat.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbImagePlat.Image = null;
                        imageBytes = null;
                    }
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomPlat.Text) || string.IsNullOrEmpty(txtPrixPlat.Text) || cbbCategorie.SelectedItem == null || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float prix;
            if (!float.TryParse(txtPrixPlat.Text, out prix))
            {
                MessageBox.Show("Le prix doit être un nombre valide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Plat WHERE nom = @nom";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, cnx))
                    {
                        checkCmd.Parameters.AddWithValue("@nom", txtNomPlat.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Ce plat existe déjà.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO Plat (nom, prix, category, description, image_plat) VALUES (@nom, @prix, @category, @description, @image_plat)";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNomPlat.Text);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.Parameters.AddWithValue("@category", cbbCategorie.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@image_plat", (object)imageBytes ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plat ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ChargerPlats();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du plat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (currentSelectedPlatId == -1)
            {
                MessageBox.Show("Veuillez sélectionner un plat à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNomPlat.Text) || string.IsNullOrEmpty(txtPrixPlat.Text) || cbbCategorie.SelectedItem == null || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float prix;
            if (!float.TryParse(txtPrixPlat.Text, out prix))
            {
                MessageBox.Show("Le prix doit être un nombre valide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string query = "UPDATE Plat SET nom = @nom, prix = @prix, category = @category, description = @description, image_plat = @image_plat WHERE Id_plat = @idPlat";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNomPlat.Text);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.Parameters.AddWithValue("@category", cbbCategorie.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@image_plat", (object)imageBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idPlat", currentSelectedPlatId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plat modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ChargerPlats();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification du plat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Cette méthode n'est plus nécessaire car le clic est géré par la colonne de bouton
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_plat, nom, prix, category, description, image_plat FROM Plat WHERE nom LIKE @recherche OR category LIKE @recherche";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    da.SelectCommand.Parameters.AddWithValue("@recherche", "%" + txtRechercher.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvPlat.DataSource = dt;
                    }
                    else
                    {
                        dgvPlat.DataSource = null; // Vider le DataGridView
                        MessageBox.Show("Aucun plat ne correspond à votre recherche.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoisirImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFd = new OpenFileDialog();
            openFd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbImagePlat.Image = new Bitmap(openFd.FileName);
                    FileStream fs = new FileStream(openFd.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageBytes = br.ReadBytes((int)fs.Length);
                    fs.Close();
                    br.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement de l'image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Efface les champs de saisie et recharge le DataGridView avec toutes les données.
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            // Appelle la méthode existante pour vider tous les champs du formulaire.
            ClearFields();

            // Appelle la méthode pour recharger toutes les données dans le DataGridView.
            ChargerPlats();
        }

        // Ces méthodes sont ajoutées pour résoudre les erreurs de compilation.
        // Ne les supprimez pas même si elles sont vides.
        private void dgvPlat_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtNomPlat_TextChanged(object sender, EventArgs e) { }
        private void txtPrixPlat_TextChanged(object sender, EventArgs e) { }
        private void cbbCategorie_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtDescription_TextChanged(object sender, EventArgs e) { }
        private void txtRechercher_TextChanged(object sender, EventArgs e) { }
        private void pbImagePlat_Click(object sender, EventArgs e) { }
        private void pictureBoxLogo_Click(object sender, EventArgs e) { }
        private void panelChamp_Paint(object sender, PaintEventArgs e) { }

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomPlat.Text) || string.IsNullOrEmpty(txtPrixPlat.Text) || cbbCategorie.SelectedItem == null || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float prix;
            if (!float.TryParse(txtPrixPlat.Text, out prix))
            {
                MessageBox.Show("Le prix doit être un nombre valide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Plat WHERE nom = @nom";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, cnx))
                    {
                        checkCmd.Parameters.AddWithValue("@nom", txtNomPlat.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Ce plat existe déjà.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO Plat (nom, prix, category, description, image_plat) VALUES (@nom, @prix, @category, @description, @image_plat)";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNomPlat.Text);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.Parameters.AddWithValue("@category", cbbCategorie.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@image_plat", (object)imageBytes ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plat ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ChargerPlats();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du plat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMiseAjour_Click(object sender, EventArgs e)
        {
            // Vérifie si un plat a été sélectionné pour la mise à jour.
            if (currentSelectedPlatId == -1)
            {
                MessageBox.Show("Veuillez sélectionner un plat à mettre à jour.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Vérifie que tous les champs sont remplis.
            if (string.IsNullOrEmpty(txtNomPlat.Text) || string.IsNullOrEmpty(txtPrixPlat.Text) || cbbCategorie.SelectedItem == null || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Déclarez la variable 'prix' avant de l'utiliser dans le TryParse.
            float prix;

            // Valide la saisie du prix.
            if (!float.TryParse(txtPrixPlat.Text, out prix))
            {
                MessageBox.Show("Le prix doit être un nombre valide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    // Construction de la requête SQL pour mettre à jour le plat.
                    string query = "UPDATE Plat SET nom = @nom, prix = @prix, category = @category, description = @description, image_plat = @image_plat WHERE Id_plat = @idPlat";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        // Ajout des paramètres pour éviter les injections SQL.
                        cmd.Parameters.AddWithValue("@nom", txtNomPlat.Text);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.Parameters.AddWithValue("@category", cbbCategorie.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@image_plat", (object)imageBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idPlat", currentSelectedPlatId);

                        // Exécution de la commande.
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Plat mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucun plat n'a été mis à jour.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                // Recharge les plats pour que le DataGridView soit à jour.
                ChargerPlats();
                // Efface les champs après la mise à jour.
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du plat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}