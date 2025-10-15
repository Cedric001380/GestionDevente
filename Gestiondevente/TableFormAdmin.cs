using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace Gestiondevente
{
    public partial class TableFormAdmin : Form
    {
        // Chaîne de connexion à la base de données
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        private byte[] imageBytes = null;
        private int currentSelectedTableId = -1;

        public TableFormAdmin()
        {
            InitializeComponent();

            // Lier l'événement CellContentClick pour les boutons dans le DataGridView
            dgvTable.CellContentClick += dgvTable_CellContentClick;

            // Assurer que le logo est rond en attachant l'événement Paint
            pictureBoxLogo.Paint += new PaintEventHandler(pictureBoxLogo_Paint);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage; // Assurer un redimensionnement correct

            // Configuration de l'image de la table
            pbImageBanc.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImageBanc.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Gère l'événement Paint pour dessiner le logo en forme de cercle.
        /// </summary>
        private void pictureBoxLogo_Paint(object sender, PaintEventArgs e)
        {
            // Activer l'anticrénelage pour des bords lisses
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (pictureBoxLogo.Image != null)
            {
                // Créer un chemin graphique en forme de cercle
                GraphicsPath path = new GraphicsPath();
                int diameter = Math.Min(pictureBoxLogo.Width, pictureBoxLogo.Height);
                path.AddEllipse(0, 0, diameter, diameter);

                // Définir la zone de découpe (region) du PictureBox
                pictureBoxLogo.Region = new Region(path);

                // Dessiner l'image dans la nouvelle zone de découpe
                e.Graphics.DrawImage(pictureBoxLogo.Image, 0, 0, pictureBoxLogo.Width, pictureBoxLogo.Height);
            }
        }

        private void TableFormAdmin_Load(object sender, EventArgs e)
        {
            ChargerTables();
            // Charger l'image du logo au démarrage, si nécessaire
            // pictureBoxLogo.Image = Image.FromFile("chemin_vers_votre_logo.png");
        }

        /// <summary>
        /// Charge les données de la table "Banc" dans le DataGridView.
        /// </summary>
        private void ChargerTables()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_table, numero_table, emplacement, statut, image_banc FROM Banc";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTable.DataSource = dt;

                    // Masquer les colonnes techniques
                    if (dgvTable.Columns.Contains("image_banc"))
                    {
                        dgvTable.Columns["image_banc"].Visible = false;
                    }
                    if (dgvTable.Columns.Contains("Id_table"))
                    {
                        dgvTable.Columns["Id_table"].Visible = false;
                    }
                    dgvTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des tables : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Vide les champs de saisie et l'image du PictureBox.
        /// </summary>
        private void ClearFields()
        {
            txtNumtable.Clear();
            txtEmplacement.Clear();
            txtStatut.Clear();
            pbImageBanc.Image = null;
            imageBytes = null;
            currentSelectedTableId = -1;
        }

        /// <summary>
        /// Gère les clics sur les boutons du DataGridView.
        /// </summary>
        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (dgvTable.Columns[e.ColumnIndex].Name == "btnModifierColumn" || dgvTable.Columns[e.ColumnIndex].Name == "btnSupprimerColumn"))
            {
                DataGridViewRow row = dgvTable.Rows[e.RowIndex];
                currentSelectedTableId = Convert.ToInt32(row.Cells["Id_table"].Value);

                if (dgvTable.Columns[e.ColumnIndex].Name == "btnModifierColumn")
                {
                    txtNumtable.Text = row.Cells["numero_table"].Value.ToString();
                    txtEmplacement.Text = row.Cells["emplacement"].Value.ToString();
                    txtStatut.Text = row.Cells["statut"].Value.ToString();

                    if (row.Cells["image_banc"].Value != DBNull.Value)
                    {
                        imageBytes = (byte[])row.Cells["image_banc"].Value;
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbImageBanc.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbImageBanc.Image = null;
                        imageBytes = null;
                    }
                }
                else if (dgvTable.Columns[e.ColumnIndex].Name == "btnSupprimerColumn")
                {
                    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette table ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection cnx = new SqlConnection(ConnectionString))
                            {
                                string query = "DELETE FROM Banc WHERE Id_table = @idTable";
                                using (SqlCommand cmd = new SqlCommand(query, cnx))
                                {
                                    cmd.Parameters.AddWithValue("@idTable", currentSelectedTableId);
                                    cnx.Open();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Table supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            ChargerTables();
                            ClearFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur lors de la suppression de la table : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_table, numero_table, emplacement, statut, image_banc FROM Banc WHERE numero_table LIKE @recherche OR emplacement LIKE @recherche";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    da.SelectCommand.Parameters.AddWithValue("@recherche", "%" + txtRechercher.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTable.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumtable.Text) || string.IsNullOrEmpty(txtEmplacement.Text) || string.IsNullOrEmpty(txtStatut.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Banc WHERE numero_table = @numero_table";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, cnx))
                    {
                        checkCmd.Parameters.AddWithValue("@numero_table", txtNumtable.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Ce numéro de table existe déjà.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO Banc (numero_table, emplacement, statut, image_banc) VALUES (@numero_table, @emplacement, @statut, @image_banc)";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@numero_table", txtNumtable.Text);
                        cmd.Parameters.AddWithValue("@emplacement", txtEmplacement.Text);
                        cmd.Parameters.AddWithValue("@statut", txtStatut.Text);
                        cmd.Parameters.AddWithValue("@image_banc", (object)imageBytes ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Table ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ChargerTables();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de la table : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (currentSelectedTableId == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une table dans le tableau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNumtable.Text) || string.IsNullOrEmpty(txtEmplacement.Text) || string.IsNullOrEmpty(txtStatut.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string query = "UPDATE Banc SET numero_table = @numero_table, emplacement = @emplacement, statut = @statut, image_banc = @image_banc WHERE Id_table = @idTable";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@numero_table", txtNumtable.Text);
                        cmd.Parameters.AddWithValue("@emplacement", txtEmplacement.Text);
                        cmd.Parameters.AddWithValue("@statut", txtStatut.Text);
                        cmd.Parameters.AddWithValue("@image_banc", (object)imageBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idTable", currentSelectedTableId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Table modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ChargerTables();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification de la table : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (currentSelectedTableId == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une table à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette table ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection cnx = new SqlConnection(ConnectionString))
                    {
                        string query = "DELETE FROM Banc WHERE Id_table = @idTable";
                        using (SqlCommand cmd = new SqlCommand(query, cnx))
                        {
                            cmd.Parameters.AddWithValue("@idTable", currentSelectedTableId);
                            cnx.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Table supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    ChargerTables();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression de la table : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    pbImageBanc.Image = new Bitmap(openFd.FileName);
                    using (FileStream fs = new FileStream(openFd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            imageBytes = br.ReadBytes((int)fs.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement de l'image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Événements d'interface utilisateur (laissés vides pour l'implémentation future)
        private void txtNumtable_TextChanged(object sender, EventArgs e) { }
        private void txtEmplacement_TextChanged(object sender, EventArgs e) { }
        private void txtStatut_TextChanged(object sender, EventArgs e) { }
        private void txtRechercher_TextChanged(object sender, EventArgs e) { }
        private void pbImageBanc_Click(object sender, EventArgs e) { }
        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnRetour_Click(object sender, EventArgs e) 
        { 
            this.Close(); 
        }
        private void pictureBoxLogo_Click(object sender, EventArgs e) { }

        private void btnMiseAjour_Click(object sender, EventArgs e)
        {
            // Vérifie si une table a été sélectionnée pour la mise à jour.
            if (currentSelectedTableId == -1)
            {
                MessageBox.Show("Veuillez sélectionner une table à mettre à jour.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Vérifie que tous les champs sont remplis.
            if (string.IsNullOrEmpty(txtNumtable.Text) || string.IsNullOrEmpty(txtEmplacement.Text) || string.IsNullOrEmpty(txtStatut.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    // Construction de la requête SQL pour mettre à jour la table.
                    string query = "UPDATE Banc SET numero_table = @numero_table, emplacement = @emplacement, statut = @statut, image_banc = @image_banc WHERE Id_table = @idTable";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        // Ajout des paramètres pour éviter les injections SQL.
                        cmd.Parameters.AddWithValue("@numero_table", txtNumtable.Text);
                        cmd.Parameters.AddWithValue("@emplacement", txtEmplacement.Text);
                        cmd.Parameters.AddWithValue("@statut", txtStatut.Text);
                        cmd.Parameters.AddWithValue("@image_banc", (object)imageBytes ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idTable", currentSelectedTableId);

                        // Exécution de la commande.
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Table mise à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucune table n'a été mise à jour.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                // Recharge les tables pour que le DataGridView soit à jour.
                ChargerTables();
                // Efface les champs après la mise à jour.
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour de la table : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}