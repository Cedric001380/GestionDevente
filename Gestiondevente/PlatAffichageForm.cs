using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;

namespace Gestiondevente
{
    public partial class PlatAffichageForm : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        public PlatAffichageForm()
        {
            InitializeComponent();
            
            // Attacher l'événement Paint pour dessiner le logo en forme de cercle
            pictureBoxLogo.Paint += new PaintEventHandler(pictureBoxLogo_Paint);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage; // Redimensionnement pour une meilleure adaptation
        }

        private void PlatAffichageForm_Load(object sender, EventArgs e)
        {
            AfficherPlats();
        }

        /// <summary>
        /// Gère l'événement Paint pour dessiner le logo en forme de cercle.
        /// </summary>
        private void pictureBoxLogo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (pictureBoxLogo.Image != null)
            {
                // Crée un chemin graphique elliptique
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, pictureBoxLogo.Width, pictureBoxLogo.Height);
                
                // Définit la région de découpe du PictureBox
                pictureBoxLogo.Region = new Region(path);

                // Dessine l'image dans la zone de découpe
                e.Graphics.DrawImage(pictureBoxLogo.Image, 0, 0, pictureBoxLogo.Width, pictureBoxLogo.Height);
            }
        }

        /// <summary>
        /// Affiche les plats de la base de données de manière plus stylisée.
        /// </summary>
        private void AfficherPlats()
        {
            try
            {
                // Vider le FlowLayoutPanel avant de charger les nouveaux plats
                flowLayoutPanel1.Controls.Clear();

                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT nom, prix, category, description, image_plat FROM Plat";
                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cnx.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Créer un panneau (carte) pour chaque plat
                        Panel platPanel = new Panel();
                        platPanel.BorderStyle = BorderStyle.FixedSingle;
                        platPanel.Size = new Size(220, 300);
                        platPanel.Margin = new Padding(15);
                        platPanel.BackColor = Color.LightGray; // Couleur de fond pour la carte

                        // PictureBox pour l'image du plat
                        PictureBox pbImage = new PictureBox();
                        pbImage.Size = new Size(200, 150);
                        pbImage.Location = new Point(10, 10);
                        pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                        pbImage.BorderStyle = BorderStyle.FixedSingle;
                        
                        if (reader["image_plat"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])reader["image_plat"];
                            MemoryStream ms = new MemoryStream(imageBytes);
                            pbImage.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pbImage.Image = null; // Aucune image
                        }

                        // Labels pour les informations
                        Label lblNom = new Label();
                        lblNom.Text = reader["nom"].ToString();
                        lblNom.Location = new Point(10, 170);
                        lblNom.Font = new Font("Arial", 12, FontStyle.Bold);
                        lblNom.AutoSize = true;

                        Label lblPrix = new Label();
                        lblPrix.Text = reader["prix"].ToString() + " Ar";
                        lblPrix.Location = new Point(10, 195);
                        lblPrix.Font = new Font("Arial", 10, FontStyle.Italic);
                        lblPrix.AutoSize = true;

                        Label lblCategorie = new Label();
                        lblCategorie.Text = "Catégorie: " + reader["category"].ToString();
                        lblCategorie.Location = new Point(10, 220);
                        lblCategorie.Font = new Font("Arial", 9, FontStyle.Regular);
                        lblCategorie.AutoSize = true;

                        Label lblDescription = new Label();
                        lblDescription.Text = reader["description"].ToString();
                        lblDescription.Location = new Point(10, 245);
                        lblDescription.Size = new Size(200, 50);
                        lblDescription.Font = new Font("Arial", 8, FontStyle.Regular);
                        lblDescription.ForeColor = Color.DarkSlateGray;

                        // Ajouter les contrôles au panneau
                        platPanel.Controls.Add(pbImage);
                        platPanel.Controls.Add(lblNom);
                        platPanel.Controls.Add(lblPrix);
                        platPanel.Controls.Add(lblCategorie);
                        platPanel.Controls.Add(lblDescription);

                        // Ajouter le panneau (la carte) au FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(platPanel);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'affichage des plats : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            // Cet événement peut être utilisé pour un clic sur le logo
        }
    }
}