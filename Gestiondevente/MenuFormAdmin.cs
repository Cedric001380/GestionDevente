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
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization; // Ajouté pour le tri chronologique des jours

namespace Gestiondevente
{
    public partial class MenuFormAdmin : Form
    {
        // ATTENTION : Modifiez ce chemin pour qu'il corresponde à votre environnement
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        // CHAMP POUR L'ID DE L'ADMINISTRATEUR CONNECTÉ
        private int _idUtilisateurConnecte;

        // CONSTRUCTEUR 1 : Surcharge pour accepter l'ID après la connexion
        public MenuFormAdmin(int idUtilisateur)
        {
            InitializeComponent();
            _idUtilisateurConnecte = idUtilisateur;

            // Charge l'image de profil au démarrage
            ChargerPhotoProfil();

            // Charge les données à l'ouverture pour le Dashboard
            ChargerTotauxGlobaux();
            ChargerTauxCommandeParJourGlobal();
            ChargerPaiementParJourGlobal();
            ChargerTopClients();
        }

        // CONSTRUCTEUR 2 : Garde le constructeur sans paramètre pour la compatibilité
        public MenuFormAdmin()
            : this(1)
        {
            // ID par défaut (1) si non spécifié.
        }

        private void MenuFormAdmin_Load(object sender, EventArgs e)
        {
            // S'assurer que le PictureBox est configuré pour afficher correctement l'image
            if (this.pbPhotoProfil != null)
            {
                this.pbPhotoProfil.SizeMode = PictureBoxSizeMode.Zoom;
            }
            // Active le DoubleBuffer pour la ListView afin de réduire le clignotement lors du dessin
            if (this.listViewUtilisateurBeaucoupCommande != null)
            {
                // Nécessite une méthode d'extension ou une astuce si vous ne pouvez pas modifier la classe ListView
                // Dans VS 2012, nous devons souvent utiliser des solutions de contournement pour le DoubleBuffering.
                // On s'appuie ici sur OwnerDraw pour le style.
            }
        }

        // ------------------------------------------
        // # REGION AMÉLIORATION DE L'INTERFACE DES GRAPHIQUES ET LISTVIEW
        // ------------------------------------------

        /// <summary>
        /// Applique un style moderne et cohérent au contrôle Chart.
        /// </summary>
        private void ConfigurerStyleGraphique(Chart chartControl, string titrePrincipal, Color couleurSerie)
        {
            // Réinitialisation ou nettoyage pour éviter les doublons
            chartControl.Series.Clear();
            chartControl.Titles.Clear();

            // 1. Titre et police
            chartControl.Titles.Add(titrePrincipal);
            chartControl.Titles[0].Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            chartControl.Titles[0].ForeColor = Color.FromArgb(52, 152, 219); // Bleu principal

            // 2. Zone de graphique (ChartArea)
            ChartArea area = chartControl.ChartAreas[0];
            area.BackColor = Color.FromArgb(248, 248, 248); // Arrière-plan plus clair
            area.BorderColor = Color.LightGray;
            area.BorderDashStyle = ChartDashStyle.Solid;
            area.BorderWidth = 1;

            // 3. Axe X (Jours)
            area.AxisX.MajorGrid.Enabled = false; // Pas de grille verticale
            area.AxisX.LineColor = Color.DarkGray;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            area.AxisX.LabelStyle.ForeColor = Color.DarkSlateGray;

            // 4. Axe Y (Valeurs)
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.LineColor = Color.DarkGray;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9f);
            area.AxisY.LabelStyle.ForeColor = Color.DarkSlateGray;

            // 5. Création de la série (Colonnes)
            var series = chartControl.Series.Add(titrePrincipal.Contains("Commandes") ? "Commandes" : "Revenus");
            series.ChartType = SeriesChartType.Column;
            series.Color = couleurSerie;

            // Rendre les colonnes plus épaisses et ajouter un effet
            series.BorderWidth = 1;
            series.ShadowOffset = 1;
            series["PointWidth"] = "0.7";

            // Afficher la valeur sur la colonne elle-même
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
        }

        /// <summary>
        /// Applique un style moderne au ListView (bandes alternées, grille, entêtes stylisés).
        /// </summary>
        private void ConfigurerStyleListView(ListView listViewControl)
        {
            // Active la grille et le dessin par le propriétaire pour la personnalisation
            listViewControl.GridLines = true;
            listViewControl.FullRowSelect = true; // Pour une meilleure UX
            listViewControl.View = View.Details;

            // Si la ListView n'a pas déjà l'OwnerDraw à True
            if (!listViewControl.OwnerDraw)
            {
                listViewControl.OwnerDraw = true;

                // Gère le dessin des sous-éléments (pour l'alternance de couleur et l'alignement)
                // Événement DrawSubItem pour les lignes
                listViewControl.DrawSubItem += (sender, e) =>
                {
                    // Couleur de fond alternée
                    Color backColor = (e.ItemIndex % 2 == 0) ? Color.FromArgb(240, 240, 240) : Color.White;
                    e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

                    Rectangle bounds = e.Bounds;

                    // Dessine le texte avec un alignement correct
                    TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;

                    // Alignement de la colonne 'Total Commandes' (index 1)
                    if (e.ColumnIndex == 1)
                    {
                        flags |= TextFormatFlags.Right;
                        // Ajouter un padding à droite
                        bounds.Width -= 5;
                        bounds.X += 5;
                    }
                    else
                    {
                        flags |= TextFormatFlags.Left;
                        // Ajouter un padding à gauche pour la première colonne
                        if (e.ColumnIndex == 0)
                        {
                            bounds.X += 5;
                            bounds.Width -= 5;
                        }
                    }

                    TextRenderer.DrawText(e.Graphics,
                                        e.SubItem.Text,
                                        new Font("Segoe UI", 9f),
                                        bounds,
                                        Color.Black, // Toujours texte noir pour les données
                                        flags);
                };

                // Gère le dessin de l'entête (pour appliquer un style personnalisé)
                // Événement DrawColumnHeader pour l'entête
                listViewControl.DrawColumnHeader += (sender, e) =>
                {
                    // Couleur d'arrière-plan de l'entête
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(52, 152, 219)), e.Bounds); // Bleu principal

                    // Dessine le texte de l'entête
                    TextRenderer.DrawText(e.Graphics,
                                        e.Header.Text,
                                        new Font("Segoe UI", 10f, FontStyle.Bold),
                                        e.Bounds,
                                        Color.White, // Texte blanc
                                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                    // Dessine la ligne de séparation droite de l'en-tête (grille verticale)
                    using (Pen p = new Pen(Color.FromArgb(39, 115, 169))) // Un bleu plus foncé
                    {
                        e.Graphics.DrawLine(p, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
                    }
                };
            }
        }


        // ------------------------------------------
        // # REGION DASHBOARD STATS ADMIN
        // ------------------------------------------

        /// <summary>
        /// Charge le nombre total de plats, commandes, bancs et utilisateurs (clients).
        /// </summary>
        private void ChargerTotauxGlobaux()
        {
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                try
                {
                    cnx.Open();

                    // 1. Total des Plats
                    using (SqlCommand cmdPlats = new SqlCommand("SELECT COUNT(*) FROM Plat", cnx))
                    {
                        lblTotalPlats.Text = cmdPlats.ExecuteScalar().ToString();
                    }

                    // 2. Total des Commandes
                    using (SqlCommand cmdCommandes = new SqlCommand("SELECT COUNT(*) FROM Commande", cnx))
                    {
                        lblTotalCommandes.Text = cmdCommandes.ExecuteScalar().ToString();
                    }

                    // 3. Total des Bancs
                    using (SqlCommand cmdTables = new SqlCommand("SELECT COUNT(*) FROM Banc", cnx))
                    {
                        lblTotalTables.Text = cmdTables.ExecuteScalar().ToString();
                    }

                    // 4. Total des Utilisateurs (Clients/Standard)
                    using (SqlCommand cmdUtilisateurs = new SqlCommand("SELECT COUNT(*) FROM Utilisateur WHERE role = 'utilisateur'", cnx))
                    {
                        lblTotalUtilisateur.Text = cmdUtilisateurs.ExecuteScalar().ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des totaux globaux : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Stat 1 : Taux de commande par jour (GLOBAL)
        private void ChargerTauxCommandeParJourGlobal()
        {
            Chart chartControl = this.chartTauxCommandeJour;

            // APPLIQUER LE STYLE
            ConfigurerStyleGraphique(chartControl,
                                     "Commandes passées (7 derniers jours)",
                                     Color.FromArgb(52, 152, 219)); // Bleu vif

            var series = chartControl.Series[0]; // Récupère la série créée dans ConfigurerStyleGraphique
            series.LabelFormat = "N0"; // Juste un nombre

            // Pour trier correctement, on utilise le type Tuple<DateTime, int> et on le convertit après
            List<Tuple<DateTime, int>> dataPoints = new List<Tuple<DateTime, int>>();

            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT TOP 7
                        CAST(date_heure AS DATE) AS Jour,
                        COUNT(Id_commande) AS TotalCommandes
                    FROM Commande
                    GROUP BY CAST(date_heure AS DATE)
                    ORDER BY Jour DESC";

                try
                {
                    cnx.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataPoints.Add(Tuple.Create(reader.GetDateTime(0), reader.GetInt32(1)));
                        }
                    }

                    // Afficher les points dans l'ordre chronologique (ASC)
                    foreach (var point in dataPoints.OrderBy(p => p.Item1))
                    {
                        // Utiliser le format "lun.", "mar." etc., en utilisant la culture locale par défaut.
                        string jourAbrege = point.Item1.ToString("ddd", CultureInfo.CurrentCulture);
                        series.Points.AddXY(jourAbrege, point.Item2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur Stat 1 : Taux Commande Global : " + ex.Message, "Erreur de Statistique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Stat 2 : Paiement par commandes par jour (Revenus encaissés GLOBAL)
        private void ChargerPaiementParJourGlobal()
        {
            Chart chartControl = this.chartPaiementParCommandeParJour;

            // APPLIQUER LE STYLE
            ConfigurerStyleGraphique(chartControl,
                                     "Revenus obtenues (7 derniers jours)",
                                     Color.FromArgb(46, 204, 113)); // Vert Vif Tracker

            var series = chartControl.Series[0]; // Récupère la série créée dans ConfigurerStyleGraphique

            // APPLIQUER LE FORMATAGE MONÉTAIRE sur l'axe Y et les labels
            chartControl.ChartAreas[0].AxisY.LabelStyle.Format = "C0"; // 'C0' pour devise, sans décimale
            series.LabelFormat = "C0"; // Format monétaire pour le label au-dessus de la colonne

            // Pour trier correctement, on utilise le type Tuple<DateTime, decimal> et on le convertit après
            List<Tuple<DateTime, decimal>> dataPoints = new List<Tuple<DateTime, decimal>>();


            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT TOP 7
                        CAST(P.date_paiement AS DATE) AS JourPaiement,
                        SUM(P.montant_total) AS Revenus
                    FROM Paiement P
                    GROUP BY CAST(P.date_paiement AS DATE)
                    ORDER BY JourPaiement DESC";

                try
                {
                    cnx.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataPoints.Add(Tuple.Create(reader.GetDateTime(0), reader.GetDecimal(1)));
                        }
                    }

                    // Afficher les points dans l'ordre chronologique (ASC)
                    foreach (var point in dataPoints.OrderBy(p => p.Item1))
                    {
                        string jourAbrege = point.Item1.ToString("ddd", CultureInfo.CurrentCulture);
                        series.Points.AddXY(jourAbrege, point.Item2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur Stat 2 : Paiement par Jour Global : " + ex.Message, "Erreur de Statistique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Stat 3 : Clients les plus fidèles (ayant fait le plus de commandes)
        private void ChargerTopClients()
        {
            ListView listViewControl = this.listViewUtilisateurBeaucoupCommande;

            // APPLIQUER LE STYLE AMÉLIORÉ DE LA LISTVIEW
            ConfigurerStyleListView(listViewControl);

            listViewControl.Items.Clear();

            // Configuration des colonnes (si elles n'existent pas)
            if (listViewControl.Columns.Count == 0)
            {
                listViewControl.Columns.Add("Nom du Client", 180);
                listViewControl.Columns.Add("Total Commandes", 120, HorizontalAlignment.Right);
            }
            // Mettre à jour la taille des colonnes dans tous les cas pour s'assurer du bon affichage de l'en-tête
            listViewControl.Columns[0].Width = 180;
            listViewControl.Columns[1].Width = 120;


            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT TOP 5
                        T2.nom + ' ' + T2.prenom AS NomComplet,
                        COUNT(T1.Id_commande) AS TotalCommandes
                    FROM Commande T1
                    INNER JOIN Utilisateur T2 ON T1.id_utilisateur = T2.Id_utilisateur
                    GROUP BY T2.nom, T2.prenom
                    ORDER BY TotalCommandes DESC";

                try
                {
                    cnx.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nomClient = reader.GetString(0);
                            int totalCommandes = reader.GetInt32(1);

                            ListViewItem item = new ListViewItem(nomClient);
                            // Ajout du sous-élément (commande)
                            item.SubItems.Add(totalCommandes.ToString());
                            listViewControl.Items.Add(item);
                        }
                    }

                    // Ajuste les colonnes pour s'adapter au contenu après le remplissage
                    // NOTE: Ne pas utiliser AutoResizeColumns(HeaderSize) avec OwnerDraw, car le dessin des données est manuel.
                    // On utilise les largeurs fixes définies ci-dessus.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur Stat 3 : Top Clients : " + ex.Message, "Erreur de Statistique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ------------------------------------------
        // # REGION GESTION DES BOUTONS DE NAVIGATION
        // ------------------------------------------

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Recharger toutes les statistiques du Dashboard Admin
            ChargerTotauxGlobaux();
            ChargerTauxCommandeParJourGlobal();
            ChargerPaiementParJourGlobal();
            ChargerTopClients();
        }

        private void btnPlat_Click(object sender, EventArgs e)
        {
            // Assurez-vous que la classe PlatAdminForm existe
            PlatAdminForm platAdminForm = new PlatAdminForm();
            platAdminForm.ShowDialog();
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            // Assurez-vous que la classe ListCommandes existe
            ListCommandes listCommandes = new ListCommandes();
            listCommandes.ShowDialog();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            // Assurez-vous que la classe TableFormAdmin existe
            TableFormAdmin tableAdminForm = new TableFormAdmin();
            tableAdminForm.ShowDialog();
        }

        private void btnPaiement_Click(object sender, EventArgs e)
        {
            // Assurez-vous que la classe ListPaiment existe
            ListPaiment listPaiment = new ListPaiment();
            listPaiment.ShowDialog();
        }

        private void btnUtilisateurs_Click(object sender, EventArgs e)
        {
            // Assurez-vous que la classe GererUtilisateursForm existe
            GererUtilisateursForm gererUtilisateursForm = new GererUtilisateursForm();
            gererUtilisateursForm.ShowDialog();
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

        // ------------------------------------------
        // # REGION LOGIQUE DE BOUTON ET PICTURE (PROFIL ADMIN)
        // ------------------------------------------

        /// <summary>
        /// Charge la photo de profil de l'utilisateur connecté depuis la base de données.
        /// </summary>
        private void ChargerPhotoProfil()
        {
            if (this.pbPhotoProfil == null) return;

            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = "SELECT image_utilisateur FROM Utilisateur WHERE id_utilisateur = @idUser";

                try
                {
                    cnx.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idUser", _idUtilisateurConnecte);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            byte[] photoData = (byte[])result;
                            using (MemoryStream ms = new MemoryStream(photoData))
                            {
                                this.pbPhotoProfil.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Erreur lors du chargement de la photo de profil : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Sauvegarde le tableau d'octets de l'image dans la colonne 'image_utilisateur' de la base de données.
        /// </summary>
        private void SauvegarderPhotoProfil(byte[] photoData)
        {
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Utilisateur SET image_utilisateur = @image WHERE id_utilisateur = @idUser";
                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    cmd.Parameters.Add("@image", SqlDbType.VarBinary, photoData.Length).Value = photoData;
                    cmd.Parameters.AddWithValue("@idUser", _idUtilisateurConnecte);

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Photo de profil mise à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur de sauvegarde dans la base de données : " + ex.Message, "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnModifierImageutilisateur_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers images (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Lire le fichier image dans un tableau d'octets
                    byte[] photoData = File.ReadAllBytes(openFileDialog.FileName);

                    // 2. Sauvegarder l'image dans la base de données
                    SauvegarderPhotoProfil(photoData);

                    // 3. Afficher immédiatement la nouvelle image dans le PictureBox
                    using (MemoryStream ms = new MemoryStream(photoData))
                    {
                        if (this.pbPhotoProfil != null)
                        {
                            this.pbPhotoProfil.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sélection ou de la sauvegarde de l'image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ------------------------------------------
        // # REGION ÉVÉNEMENTS LAISSÉS POUR COMPATIBILITÉ (ÉVITE LES ERREURS SI PRÉSENTS DANS LE DESIGNER)
        // ------------------------------------------

        private void panelTables_Paint(object sender, PaintEventArgs e) { }
        private void panelPlats_Paint(object sender, PaintEventArgs e) { }
        private void panelCommande_Paint(object sender, PaintEventArgs e) { }
        private void panelPaiement_Paint(object sender, PaintEventArgs e) { }
        private void panelPlat_Paint(object sender, PaintEventArgs e) { }
        private void chartTauxCommandeJour_Click(object sender, EventArgs e) { }
        private void chartPaiementParCommandeParJour_Click(object sender, EventArgs e) { }
        private void listViewUtilisateurBeaucoupCommande_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblTotalUtilisateur_Click(object sender, EventArgs e) { }
        private void lblTotalPlats_Click(object sender, EventArgs e) { }
        private void lblTotalCommandes_Click(object sender, EventArgs e) { }
        private void lblTotalTables_Click(object sender, EventArgs e) { }
        private void pbPhotoProfil_Click(object sender, EventArgs e) { }

        private void btnUser_Click(object sender, EventArgs e)
        {
            GererUtilisateursForm formutilisateur = new GererUtilisateursForm();
            formutilisateur.Show();
        }
    }
}