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

namespace Gestiondevente
{
    public partial class MainAffichageForm : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        private List<PlatCommande> panier = new List<PlatCommande>();
        private int tableSelectionneeId = -1;
        private int idUtilisateurConnecte;

        public MainAffichageForm(int utilisateurId)
        {
            InitializeComponent();
            idUtilisateurConnecte = utilisateurId;
        }

        public MainAffichageForm()
        {
            InitializeComponent();
            idUtilisateurConnecte = -1; // Valeur par défaut pour les cas où aucun utilisateur n'est passé
        }

        private void MainAffichageForm_Load(object sender, EventArgs e)
        {
            AfficherPlats();
            AfficherTables();
            MettreAJourTotal();
        }

        private void AfficherPlats()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_plat, nom, prix, category, description, image_plat FROM Plat";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cnx.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelPlats.Controls.Clear();
                            while (reader.Read())
                            {
                                Panel platPanel = new Panel();
                                platPanel.BorderStyle = BorderStyle.FixedSingle;
                                platPanel.Size = new Size(250, 380);
                                platPanel.Margin = new Padding(10);

                                PictureBox pbImage = new PictureBox();
                                pbImage.Size = new Size(230, 150);
                                pbImage.Location = new Point(10, 10);
                                pbImage.SizeMode = PictureBoxSizeMode.Zoom;

                                try
                                {
                                    byte[] imageBytes = reader["image_plat"] as byte[];
                                    if (imageBytes != null && imageBytes.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imageBytes))
                                        {
                                            pbImage.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pbImage.Image = null;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    pbImage.Image = null;
                                    MessageBox.Show("Erreur lors du chargement de l'image du plat : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                Label lblNom = new Label();
                                lblNom.Text = "Nom: " + reader["nom"].ToString();
                                lblNom.Location = new Point(10, 170);
                                lblNom.AutoSize = true;

                                Label lblPrix = new Label();
                                float prix = Convert.ToSingle(reader["prix"]);
                                lblPrix.Text = "Prix: " + prix.ToString("N0") + " Ar";
                                lblPrix.Location = new Point(10, 200);
                                lblPrix.AutoSize = true;

                                Label lblCategorie = new Label();
                                lblCategorie.Text = "Catégorie: " + reader["category"].ToString();
                                lblCategorie.Location = new Point(10, 230);
                                lblCategorie.AutoSize = true;

                                Label lblDescription = new Label();
                                lblDescription.Text = "Description: " + reader["description"].ToString();
                                lblDescription.Location = new Point(10, 260);
                                lblDescription.Size = new Size(230, 50);

                                Button btnAjouterPanier = new Button();
                                btnAjouterPanier.Text = "Ajouter au panier";
                                btnAjouterPanier.Tag = new PlatCommande { Id_plat = (int)reader["Id_plat"], Nom = reader["nom"].ToString(), Prix = prix };
                                btnAjouterPanier.Location = new Point(10, 320);
                                btnAjouterPanier.Width = 230;
                                btnAjouterPanier.Click += BtnAjouterPanier_Click;

                                platPanel.Controls.Add(pbImage);
                                platPanel.Controls.Add(lblNom);
                                platPanel.Controls.Add(lblPrix);
                                platPanel.Controls.Add(lblCategorie);
                                platPanel.Controls.Add(lblDescription);
                                platPanel.Controls.Add(btnAjouterPanier);

                                flowLayoutPanelPlats.Controls.Add(platPanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'affichage des plats : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherTables()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_table, numero_table, emplacement, statut, image_banc FROM Banc";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cnx.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelTables.Controls.Clear();
                            while (reader.Read())
                            {
                                Panel tablePanel = new Panel();
                                tablePanel.BorderStyle = BorderStyle.FixedSingle;
                                tablePanel.Size = new Size(200, 250);
                                tablePanel.Margin = new Padding(10);
                                tablePanel.Cursor = Cursors.Hand;
                                tablePanel.Tag = reader["Id_table"];
                                tablePanel.Click += TablePanel_Click;

                                PictureBox pbImage = new PictureBox();
                                pbImage.Size = new Size(180, 120);
                                pbImage.Location = new Point(10, 10);
                                pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                                pbImage.Click += TablePanel_Click;

                                try
                                {
                                    byte[] imageBytes = reader["image_banc"] as byte[];
                                    if (imageBytes != null && imageBytes.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imageBytes))
                                        {
                                            pbImage.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pbImage.Image = null;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    pbImage.Image = null;
                                    MessageBox.Show("Erreur lors du chargement de l'image de la table : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                Label lblNumero = new Label();
                                lblNumero.Text = "Numéro: " + reader["numero_table"].ToString();
                                lblNumero.Location = new Point(10, 140);
                                lblNumero.AutoSize = true;
                                lblNumero.Click += TablePanel_Click;

                                Label lblEmplacement = new Label();
                                lblEmplacement.Text = "Emplacement: " + reader["emplacement"].ToString();
                                lblEmplacement.Location = new Point(10, 170);
                                lblEmplacement.AutoSize = true;
                                lblEmplacement.Click += TablePanel_Click;

                                Label lblStatut = new Label();
                                lblStatut.Text = "Statut: " + reader["statut"].ToString();
                                lblStatut.Location = new Point(10, 200);
                                lblStatut.AutoSize = true;
                                lblStatut.Click += TablePanel_Click;

                                tablePanel.Controls.Add(pbImage);
                                tablePanel.Controls.Add(lblNumero);
                                tablePanel.Controls.Add(lblEmplacement);
                                tablePanel.Controls.Add(lblStatut);

                                flowLayoutPanelTables.Controls.Add(tablePanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'affichage des tables : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TablePanel_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanelTables.Controls)
            {
                if (ctrl is Panel)
                {
                    Panel p = (Panel)ctrl;
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.BackColor = Color.Transparent;
                }
            }

            Control clickedControl = sender as Control;
            Panel selectedPanel = clickedControl as Panel;
            if (selectedPanel == null)
            {
                selectedPanel = clickedControl.Parent as Panel;
            }

            if (selectedPanel != null && selectedPanel.Tag != null)
            {
                selectedPanel.BorderStyle = BorderStyle.Fixed3D;
                selectedPanel.BackColor = Color.LightGreen;

                tableSelectionneeId = (int)selectedPanel.Tag;

                string numeroTable = selectedPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("Numéro:")).Text.Replace("Numéro: ", "");
                MessageBox.Show("Table numéro " + numeroTable + " sélectionnée.", "Table sélectionnée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAjouterPanier_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is PlatCommande)
            {
                PlatCommande nouveauPlat = (PlatCommande)btn.Tag;

                PlatCommande platExistant = panier.FirstOrDefault(p => p.Id_plat == nouveauPlat.Id_plat);

                if (platExistant != null)
                {
                    platExistant.Quantite++;
                }
                else
                {
                    nouveauPlat.Quantite = 1;
                    panier.Add(nouveauPlat);
                }

                MettreAJourTotal();
                lsbPanier.Items.Clear();
                foreach (var p in panier)
                {
                    lsbPanier.Items.Add(string.Format("{0} (x{1})", p.Nom, p.Quantite));
                }

                MessageBox.Show(string.Format("{0} a été ajouté au panier.", nouveauPlat.Nom), "Ajouté", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MettreAJourTotal()
        {
            float total = 0;
            foreach (var item in panier)
            {
                total += item.Prix * item.Quantite;
            }
            lblTotal.Text = "Total : " + total.ToString("N0") + " Ar";
        }

        private void btnCommander_Click_1(object sender, EventArgs e)
        {
            if (panier.Count > 0)
            {
                if (tableSelectionneeId != -1)
                {
                    if (idUtilisateurConnecte == -1)
                    {
                        MessageBox.Show("Aucun utilisateur connecté. Veuillez vous reconnecter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FormulaireCommande formulaireCommande = new FormulaireCommande(panier, tableSelectionneeId, idUtilisateurConnecte);
                    formulaireCommande.ShowDialog();

                    panier.Clear();
                    lsbPanier.Items.Clear();
                    MettreAJourTotal();

                    tableSelectionneeId = -1;
                    AfficherTables();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une table avant de commander.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Votre panier est vide.", "Panier vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grpPanier_Enter(object sender, EventArgs e) { }
        private void pictureBoxLogo_Click(object sender, EventArgs e) { }
        private void lsbPanier_SelectedIndexChanged(object sender, EventArgs e) { }

        private void flowLayoutPanelPlats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}