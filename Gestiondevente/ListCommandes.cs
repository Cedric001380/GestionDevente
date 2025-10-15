using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestiondevente
{
    public partial class ListCommandes : Form
    {
        // ATTENTION : Modifiez ce chemin pour qu'il corresponde à votre environnement
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        // idCommandeSelectionnee n'est plus strictement nécessaire pour le clic sur le bouton, 
        // mais nous le gardons pour les autres fonctionnalités si vous en avez besoin.
        private int idCommandeSelectionnee = 0;

        public ListCommandes()
        {
            InitializeComponent();

            ApplyDataGridViewStyles();

            // Attacher l'événement principal pour intercepter le clic sur la colonne Bouton
            dgvCommandes.CellContentClick += dgvCommandes_CellContentClick;

            // Attacher l'événement pour le style de statut
            dgvCommandes.DataBindingComplete += dgvCommandes_DataBindingComplete;

            ChargerCommandes();
        }

        /// <summary>
        /// Applique un style moderne et professionnel au DataGridView.
        /// </summary>
        private void ApplyDataGridViewStyles()
        {
            // --- Style de l'En-tête (Header) ---
            dgvCommandes.EnableHeadersVisualStyles = false;
            dgvCommandes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); // Bleu foncé élégant
            dgvCommandes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCommandes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCommandes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // --- Style des Cellules et Lignes ---
            dgvCommandes.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvCommandes.RowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248); // Gris très clair
            dgvCommandes.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Alternance de couleurs

            // Ligne sélectionnée
            dgvCommandes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 149, 237); // Bleu maïs/royal
            dgvCommandes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Autres propriétés importantes
            dgvCommandes.GridColor = Color.LightGray;
            dgvCommandes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCommandes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCommandes.ReadOnly = true;
        }

        /// <summary>
        /// Configure l'affichage et le style de toutes les colonnes, y compris la colonne Bouton.
        /// </summary>
        private void SetupDataGridViewColumns()
        {
            // Supprimer toutes les colonnes existantes pour éviter les doublons ou conflits
            dgvCommandes.Columns.Clear();

            // 1. Ajouter les colonnes de données (après que le DataSource est lié et que les colonnes automatiques existent)
            if (dgvCommandes.Columns.Contains("Id_commande"))
            {
                dgvCommandes.Columns["Id_commande"].Visible = false;
            }

            if (dgvCommandes.Columns.Contains("date_heure"))
            {
                dgvCommandes.Columns["date_heure"].HeaderText = "Date et Heure";
                dgvCommandes.Columns["date_heure"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvCommandes.Columns["date_heure"].FillWeight = 150; // Ajuster la taille
            }

            if (dgvCommandes.Columns.Contains("NomCompletClient"))
            {
                dgvCommandes.Columns["Nom du Client"].HeaderText = "Client";
                dgvCommandes.Columns["Nom du Client"].FillWeight = 200;
            }

            if (dgvCommandes.Columns.Contains("statut"))
            {
                dgvCommandes.Columns["statut"].HeaderText = "Statut";
                dgvCommandes.Columns["statut"].FillWeight = 100;
                // Aligner le statut au centre pour la lisibilité
                dgvCommandes.Columns["statut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 2. Ajouter la DataGridViewButtonColumn pour la suppression
            DataGridViewButtonColumn btnSupprimerColumn = new DataGridViewButtonColumn();
            {
                btnSupprimerColumn.Name = "btnSupprimerColumn"; // Nom interne pour l'identifier dans l'événement de clic
                btnSupprimerColumn.HeaderText = "Action";
                btnSupprimerColumn.Text = "Supprimer";
                btnSupprimerColumn.UseColumnTextForButtonValue = true;
                btnSupprimerColumn.Width = 100; // Taille fixe pour les boutons d'action
                btnSupprimerColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Désactiver le Fill pour ce bouton

                // Style du bouton (Rouge pour la suppression)
                btnSupprimerColumn.DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60); // Rouge vif
                btnSupprimerColumn.DefaultCellStyle.ForeColor = Color.White;
                btnSupprimerColumn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 57, 43); // Rouge foncé au survol
            }

            // Ajouter la colonne à la fin
            dgvCommandes.Columns.Add(btnSupprimerColumn);
        }

        /// <summary>
        /// Charge les commandes depuis la base de données.
        /// </summary>
        private void ChargerCommandes()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = @"
                        SELECT
                            c.Id_commande,
                            c.date_heure,
                            u.prenom + ' ' + u.nom AS NomCompletClient,
                            c.statut
                        FROM
                            Commande c
                        JOIN
                            Utilisateur u ON c.Id_utilisateur = u.Id_utilisateur
                        ORDER BY
                            c.date_heure DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCommandes.DataSource = dt;

                    // Configurer les colonnes après le chargement des données
                    SetupDataGridViewColumns();

                    idCommandeSelectionnee = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des commandes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Applique un style conditionnel au DataGridView en fonction du statut.
        /// </summary>
        private void dgvCommandes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvCommandes.Rows.Count == 0 || !dgvCommandes.Columns.Contains("statut"))
            {
                return;
            }

            foreach (DataGridViewRow row in dgvCommandes.Rows)
            {
                // Réinitialiser le style de fond pour les lignes alternées
                row.DefaultCellStyle.BackColor = row.Index % 2 == 0 ?
                    dgvCommandes.RowsDefaultCellStyle.BackColor :
                    dgvCommandes.AlternatingRowsDefaultCellStyle.BackColor;

                if (row.Cells["statut"].Value != null)
                {
                    string statut = row.Cells["statut"].Value.ToString().ToLower();

                    // Utiliser un style distinct pour la cellule statut
                    DataGridViewCellStyle statutCellStyle = new DataGridViewCellStyle();
                    statutCellStyle.Font = new Font(dgvCommandes.DefaultCellStyle.Font, FontStyle.Bold);
                    statutCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    switch (statut)
                    {
                        case "terminée":
                        case "payée":
                            statutCellStyle.ForeColor = Color.DarkGreen;
                            statutCellStyle.BackColor = Color.FromArgb(204, 255, 204); // Fond vert clair
                            break;
                        case "en cours":
                        case "préparation":
                            statutCellStyle.ForeColor = Color.DarkOrange;
                            statutCellStyle.BackColor = Color.FromArgb(255, 240, 204); // Fond orange clair
                            break;
                        case "annulée":
                            statutCellStyle.ForeColor = Color.DarkRed;
                            statutCellStyle.BackColor = Color.FromArgb(255, 204, 204); // Fond rouge clair
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Ligne entière rouge très clair
                            break;
                        default:
                            statutCellStyle.ForeColor = Color.DarkGray;
                            statutCellStyle.BackColor = Color.LightGray;
                            break;
                    }

                    row.Cells["statut"].Style = statutCellStyle;
                }
            }
        }

        // --- GESTION DES CLICS SUR LE DATAGRIDVIEW ---

        // dgvCommandes_CellClick est utilisé pour la sélection de ligne standard
        private void dgvCommandes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Logique de sélection standard pour les autres boutons/actions
            if (e.RowIndex >= 0 && dgvCommandes.Columns.Contains("Id_commande"))
            {
                DataGridViewRow row = dgvCommandes.Rows[e.RowIndex];
                if (row.Cells["Id_commande"].Value != DBNull.Value)
                {
                    idCommandeSelectionnee = Convert.ToInt32(row.Cells["Id_commande"].Value);
                    // Mettez à jour l'état de vos boutons (btnModifier/btnSupprimer) si vous les avez toujours
                    // btnModifier.Enabled = true; 
                    // btnSupprimer.Enabled = true;
                }
            }
        }

        // dgvCommandes_CellContentClick est OBLIGATOIRE pour intercepter le clic sur DataGridViewButtonColumn
        private void dgvCommandes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Vérifiez que l'utilisateur a cliqué sur la colonne du bouton "Supprimer"
            if (dgvCommandes.Columns[e.ColumnIndex].Name == "btnSupprimerColumn" && e.RowIndex >= 0)
            {
                // 2. Récupérez l'ID de la commande de la ligne cliquée
                int idCommandeASupprimer = 0;
                if (dgvCommandes.Columns.Contains("Id_commande") && dgvCommandes.Rows[e.RowIndex].Cells["Id_commande"].Value != DBNull.Value)
                {
                    idCommandeASupprimer = Convert.ToInt32(dgvCommandes.Rows[e.RowIndex].Cells["Id_commande"].Value);
                }

                if (idCommandeASupprimer > 0)
                {
                    // 3. Exécutez la suppression
                    DemandeSuppression(idCommandeASupprimer);
                }
            }
        }


        // --- LOGIQUE DE SUPPRESSION AMÉLIORÉE ---

        private void DemandeSuppression(int idCommande)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer définitivement la commande ID: " + idCommande + " ? Cette action est irréversible et supprimera tous les détails.", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SupprimerCommandeParId(idCommande);

                    MessageBox.Show("Commande supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerCommandes(); // Recharger les données après la suppression
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression de la commande. Détails: " + ex.Message, "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Exécute la suppression transactionnelle de la commande et de ses détails.
        /// </summary>
        private void SupprimerCommandeParId(int idCommande)
        {
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                // Utilisation d'une transaction pour garantir la cohérence des données
                SqlTransaction transaction = cnx.BeginTransaction();
                try
                {
                    // 1. Supprimer les détails de la commande
                    using (SqlCommand cmdDeleteDetails = new SqlCommand("DELETE FROM DetailsCommande WHERE id_commande = @idCommande", cnx, transaction))
                    {
                        cmdDeleteDetails.Parameters.AddWithValue("@idCommande", idCommande);
                        cmdDeleteDetails.ExecuteNonQuery();
                    }

                    // 2. Supprimer la commande elle-même
                    using (SqlCommand cmdDeleteCommande = new SqlCommand("DELETE FROM Commande WHERE Id_commande = @idCommande", cnx, transaction))
                    {
                        cmdDeleteCommande.Parameters.AddWithValue("@idCommande", idCommande);
                        cmdDeleteCommande.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    // Rejeter l'exception pour être capturée par la méthode appelante
                    throw;
                }
            }
        }


        // --- AUTRES LOGIQUES DE BOUTONS ---

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (idCommandeSelectionnee == 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Lancement du formulaire de modification pour la commande ID : " + idCommandeSelectionnee, "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNouveauCommandes_Click(object sender, EventArgs e)
        {
            MainAffichageForm commanderForm = new MainAffichageForm();
            commanderForm.Show();
        }

        // Événement laissé vide pour compatibilité avec le designer
        private void ListCommandes_Load(object sender, EventArgs e) { }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}