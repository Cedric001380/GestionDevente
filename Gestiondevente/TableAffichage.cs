using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gestiondevente
{
    public partial class TableAffichage : Form
    {
        // Chaîne de connexion à la base de données.
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        public TableAffichage()
        {
            InitializeComponent();
            ChargerTables();
        }

        private void ChargerTables()
        {
            // Note: Pour cette version, il serait préférable d'utiliser un TableLayoutPanel
            // dans le designer et de le nommer flowLayoutPanelTables.
            flowLayoutPanelTables.Controls.Clear();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_table, numero_table, emplacement, statut, image_banc FROM Banc ORDER BY Id_table";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Panel pnlCard = new Panel();
                        pnlCard.Width = 200;
                        pnlCard.Height = 250;
                        pnlCard.Margin = new Padding(15);
                        pnlCard.BorderStyle = BorderStyle.FixedSingle;
                        pnlCard.BackColor = Color.White;

                        // PictureBox pour l'image
                        PictureBox pbImage = new PictureBox();
                        pbImage.SizeMode = PictureBoxSizeMode.Zoom; // Utilise Zoom pour un meilleur ajustement de l'image
                        pbImage.Width = 180;
                        pbImage.Height = 150;
                        pbImage.Location = new Point(10, 10);
                        pbImage.BorderStyle = BorderStyle.None;

                        if (row["image_banc"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])row["image_banc"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pbImage.Image = Image.FromStream(ms);
                            }
                        }
                        pnlCard.Controls.Add(pbImage);

                        // Label pour le numéro de la table
                        Label lblNumero = new Label();
                        lblNumero.Text = "Table " + row["numero_table"].ToString();
                        lblNumero.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        lblNumero.AutoSize = true;
                        lblNumero.Location = new Point(10, 170);
                        pnlCard.Controls.Add(lblNumero);

                        // Label pour le statut
                        Label lblStatut = new Label();
                        string statut = row["statut"].ToString();
                        lblStatut.Text = statut;
                        lblStatut.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                        lblStatut.AutoSize = true;
                        lblStatut.Location = new Point(10, 200);
                        pnlCard.Controls.Add(lblStatut);

                        // Indicateur visuel du statut (petit panneau coloré)
                        Panel pnlIndicator = new Panel();
                        pnlIndicator.Width = 15;
                        pnlIndicator.Height = 15;
                        pnlIndicator.BorderStyle = BorderStyle.None;
                        pnlIndicator.Location = new Point(pnlCard.Width - 30, 175);
                        pnlCard.Controls.Add(pnlIndicator);

                        if (statut.ToLower() == "disponible")
                        {
                            pnlCard.BorderStyle = BorderStyle.FixedSingle;
                            pnlCard.BackColor = Color.Honeydew; // Fond vert doux
                            pnlIndicator.BackColor = Color.ForestGreen;
                            lblNumero.ForeColor = Color.ForestGreen;
                            lblStatut.ForeColor = Color.ForestGreen;
                        }
                        else if (statut.ToLower() == "occupée")
                        {
                            pnlCard.BorderStyle = BorderStyle.FixedSingle;
                            pnlCard.BackColor = Color.MistyRose; // Fond rouge doux
                            pnlIndicator.BackColor = Color.IndianRed;
                            lblNumero.ForeColor = Color.IndianRed;
                            lblStatut.ForeColor = Color.IndianRed;
                        }

                        // Ajout de l'ombre portée (si disponible pour votre version de Windows Forms)
                        // Vous pouvez utiliser un panel avec un léger décalage pour simuler une ombre
                        // Ce n'est pas supporté nativement et nécessite une implémentation plus complexe
                        // ou l'utilisation d'une librairie tierce.

                        flowLayoutPanelTables.Controls.Add(pnlCard);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des tables : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}