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
using System.Windows.Forms.DataVisualization.Charting; // NECESSAIRE pour les graphiques Chart

namespace Gestiondevente
{
    public partial class MenuForm : Form
    {
        // ATTENTION : Modifiez ce chemin pour qu'il corresponde à votre environnement
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";
        private int idUtilisateurConnecte;

        // Assurez-vous d'avoir ajouté un composant ImageList au formulaire et nommé 'imageListPlats'
        private ImageList imageListPlats;

        public MenuForm(int utilisateurId)
        {
            InitializeComponent();
            idUtilisateurConnecte = utilisateurId;
            this.pbPhotoProfil.Resize += new EventHandler(pbPhotoProfil_Resize);
            SetPictureBoxRound();
            ChargerPhotoProfil();

            // Initialisation de l'ImageList (si non fait dans le designer)
            // Si vous l'avez fait dans le designer, cette ligne n'est pas nécessaire
            // this.imageListPlats = new ImageList(); 
            // this.listViewPlatLePlusCommande.SmallImageList = this.imageListPlats; 
        }

        public MenuForm()
        {
            InitializeComponent();
            idUtilisateurConnecte = -1;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // Assurez-vous que l'ImageList est bien lié
            // Si vous avez nommé votre ImageList dans le designer "imageListPlats"
            this.imageListPlats = new ImageList();
            this.imageListPlats.ImageSize = new Size(32, 32); // Taille des icônes
            this.listViewPlatLePlusCommande.SmallImageList = this.imageListPlats;


            // Charge les statistiques par défaut lorsque le formulaire s'ouvre
            if (idUtilisateurConnecte != -1)
            {
                ChargerTauxCommandeParJour();
                ChargerPaiementParJour();
                ChargerTopPlatsVendus();
            }
        }

        // ------------------------------------------
        // # REGION GESTION DU PROFIL (Rond, Photo)
        // ------------------------------------------
        private void SetPictureBoxRound()
        {
            GraphicsPath gp = new GraphicsPath();
            // Utilise les dimensions actuelles du PictureBox
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
                            // Vous pouvez définir une image par défaut si aucune photo n'existe
                            // pbPhotoProfil.Image = Properties.Resources.DefaultUserImage; 
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

        // ------------------------------------------
        // # REGION LOGIQUE DES STATISTIQUES
        // ------------------------------------------

        private void ChargerTotaux()
        {
            // Contient la logique pour charger les totaux globaux (Plats, Commandes, Tables)
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                try
                {
                    cnx.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des totaux globaux : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Stat 1 : Taux de commande par jour (Graphique en Barres)
        private void ChargerTauxCommandeParJour()
        {
            // Récupère votre composant Chart (assurez-vous du nom exact)
            Chart chartControl = this.chartTauxCommandeJour;

            chartControl.Series.Clear();
            chartControl.Titles.Clear();
            chartControl.Titles.Add("Commandes passées (7 derniers jours)");

            var series = chartControl.Series.Add("Commandes");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(70, 130, 180);
            chartControl.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT TOP 7
                        CAST(date_heure AS DATE) AS Jour,
                        COUNT(Id_commande) AS TotalCommandes
                    FROM Commande
                    WHERE
                        id_utilisateur = @idUser
                    GROUP BY CAST(date_heure AS DATE)
                    ORDER BY Jour DESC";

                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Remplir les données dans l'ordre croissant des jours pour le graphique
                    List<Tuple<string, int>> dataPoints = new List<Tuple<string, int>>();
                    while (reader.Read())
                    {
                        dataPoints.Add(Tuple.Create(reader.GetDateTime(0).ToString("ddd"), reader.GetInt32(1)));
                    }
                    reader.Close();

                    // Ajout des points dans l'ordre inverse pour afficher le passé vers le présent
                    foreach (var point in dataPoints.OrderBy(p => p.Item1))
                    {
                        series.Points.AddXY(point.Item1, point.Item2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur Taux Commande par Jour : " + ex.Message, "Erreur de Statistique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Stat 2 : Paiement par commandes par jour (Revenus encaissés)
        private void ChargerPaiementParJour()
        {
            // Récupère votre composant Chart (assurez-vous du nom exact)
            Chart chartControl = this.chartPaiementParCommandeParJour;

            chartControl.Series.Clear();
            chartControl.Titles.Clear();
            chartControl.Titles.Add("Revenus encaissés (7 derniers jours)");

            var series = chartControl.Series.Add("Revenus");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(46, 204, 113);
            chartControl.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT TOP 7
                        CAST(P.date_paiement AS DATE) AS JourPaiement,
                        SUM(P.montant_total) AS Revenus
                    FROM Paiement P
                    WHERE
                        P.id_utilisateur = @idUser
                    GROUP BY CAST(P.date_paiement AS DATE)
                    ORDER BY JourPaiement DESC";

                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Tuple<string, decimal>> dataPoints = new List<Tuple<string, decimal>>();
                    while (reader.Read())
                    {
                        dataPoints.Add(Tuple.Create(reader.GetDateTime(0).ToString("ddd"), reader.GetDecimal(1)));
                    }
                    reader.Close();

                    foreach (var point in dataPoints.OrderBy(p => p.Item1))
                    {
                        decimal revenus = point.Item2;

                        // CORRECTION D'ERREUR : AddXY retourne un index (int), pas un DataPoint.
                        int pointIndex = series.Points.AddXY(point.Item1, revenus);

                        // Accès au DataPoint via l'index
                        DataPoint dp = series.Points[pointIndex];
                        dp.Label = revenus.ToString("C"); // Affiche le montant au-dessus de la barre
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur Paiement par Jour : " + ex.Message, "Erreur de Statistique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Stat 3 : Plats le plus vendus (Liste avec Image)
        private void ChargerTopPlatsVendus()
        {
            ListView listViewControl = this.listViewPlatLePlusCommande;

            listViewControl.Items.Clear();
            this.imageListPlats.Images.Clear(); // Nettoyer l'ImageList avant de la remplir

            // Configuration des colonnes (si non fait dans le designer)
            if (listViewControl.Columns.Count == 0)
            {
                listViewControl.View = View.Details;
                listViewControl.Columns.Add("Plat", 200);
                listViewControl.Columns.Add("Quantité", 100, HorizontalAlignment.Right);
            }

            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                // REQUÊTE MISE À JOUR : Ajout de la colonne T3.image_plat
                string query = @"
                    SELECT TOP 5 
                        T3.nom AS NomPlat, 
                        SUM(T2.quantite) AS TotalVendu,
                        T3.image_plat AS ImagePlat 
                    FROM Commande T1
                    INNER JOIN DetailsCommande T2 ON T1.Id_commande = T2.id_commande
                    INNER JOIN Plat T3 ON T2.id_plat = T3.Id_plat
                    WHERE T1.id_utilisateur = @idUser
                    GROUP BY T3.nom, T3.image_plat
                    ORDER BY TotalVendu DESC";

                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int imageIndex = 0;

                    while (reader.Read())
                    {
                        string nomPlat = reader.GetString(0);
                        int quantite = reader.GetInt32(1);
                        object imageData = reader["ImagePlat"]; // Récupère les données binaires de l'image

                        // 1. GESTION DE L'IMAGE
                        if (imageData != DBNull.Value && imageData != null)
                        {
                            byte[] imageBytes = (byte[])imageData;
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                // Ajout de l'image à l'ImageList
                                this.imageListPlats.Images.Add(Image.FromStream(ms));
                            }
                        }
                        else
                        {
                            // Ajout d'une image par défaut (facultatif, si vous en avez une)
                            this.imageListPlats.Images.Add(new Bitmap(32, 32));
                        }

                        // 2. AJOUT AU LISTVIEW
                        ListViewItem item = new ListViewItem(nomPlat, imageIndex); // L'index lie l'image
                        item.SubItems.Add(quantite.ToString());
                        listViewControl.Items.Add(item);

                        imageIndex++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur Top Plats Vendus (avec images) : " + ex.Message, "Erreur de Statistique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ------------------------------------------
        // # REGION GESTION DES BOUTONS DE NAVIGATION
        // ------------------------------------------

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Recharge toutes les statistiques de l'utilisateur
            if (idUtilisateurConnecte != -1)
            {
                ChargerTauxCommandeParJour();
                ChargerPaiementParJour();
                ChargerTopPlatsVendus();
            }
            else
            {
                MessageBox.Show("Aucun utilisateur connecté. Statistiques non disponibles.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ... (Autres méthodes de boutons comme btnPlat_Click, btnCommande_Click, etc. restent inchangées) ...

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

        private void btnPaiment_Click(object sender, EventArgs e)
        {
            PaiementUtilisateur paiementForm = new PaiementUtilisateur();
            paiementForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // deconnexion avec un message de confirmation
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();

                try
                {
                    // Assurez-vous que la classe LoginForm existe
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
                catch { }
            }
        }

        // ... (Méthodes de gestion d'image de profil restent inchangées) ...

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


        // Méthodes d'événement vides laissées pour la compatibilité
        private void panelPlats_Paint(object sender, PaintEventArgs e) { }
        private void panelCommandes_Paint(object sender, EventArgs e) { }
        private void panelTables_Paint(object sender, EventArgs e) { }
        private void lblTotalPlats_Click(object sender, EventArgs e) { }
        private void lblTotalCommandes_Click(object sender, EventArgs e) { }
        private void lblTotalTables_Click(object sender, EventArgs e) { }
        private void pbPhotoProfil_Click(object sender, EventArgs e) { }
        private void pbPhotoProfil_Paint(object sender, PaintEventArgs e) { }
        private void panelCommande_Paint(object sender, PaintEventArgs e) { }
        private void chartTauxCommandeJour_Click(object sender, EventArgs e) { }
        private void panelPaiement_Paint(object sender, PaintEventArgs e) { }
        private void chartPaiementParCommandeParJour_Click(object sender, EventArgs e) { }
        private void listViewPlatLePlusCommande_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panelPlat_Paint(object sender, PaintEventArgs e) { }
    }
}