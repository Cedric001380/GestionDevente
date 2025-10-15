using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Gestiondevente
{
    public partial class ListPaiment : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        // Configuration SMTP (à personnaliser avec tes identifiants)
        private const string SmtpServer = "smtp.gmail.com"; // Serveur Gmail
        private const int SmtpPort = 587; // Port pour TLS
        private const string SmtpUser = "andycedric65@gmail.com"; // Remplace par ton email Gmail
        private const string SmtpPassword = "mrhe bqgq oiht rhxi"; // Remplace par ton App Password ou mot de passe

        public ListPaiment()
        {
            InitializeComponent();
            ChargerPaiements();
        }

        private void ChargerPaiements()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    // ATTENTION : Ajout du champ 'code_secret' dans la sélection SQL
                    string query = @"
                        SELECT p.Id_paiement, p.id_commande, c.statut AS statut_commande, p.statut_paiement, 
                               p.montant_total, p.nom_tut_carte, p.numero_carte, p.date_expiration, p.code_secret, p.email_vraie
                        FROM Paiement p
                        INNER JOIN Commande c ON p.id_commande = c.id_commande
                        WHERE p.statut_paiement = 'En attente'";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        if (dataGridViewPaiment == null)
                        {
                            MessageBox.Show("Le contrôle dataGridViewPaiment n'est pas initialisé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        dataGridViewPaiment.DataSource = dt;

                        // Configuration de l'affichage des colonnes
                        dataGridViewPaiment.Columns["Id_paiement"].HeaderText = "ID Paiement";
                        dataGridViewPaiment.Columns["id_commande"].HeaderText = "ID Commande";
                        dataGridViewPaiment.Columns["statut_commande"].HeaderText = "Statut Commande";
                        dataGridViewPaiment.Columns["statut_paiement"].HeaderText = "Statut Paiement";
                        dataGridViewPaiment.Columns["montant_total"].HeaderText = "Montant Total (Ar)";
                        dataGridViewPaiment.Columns["montant_total"].DefaultCellStyle.Format = "N0";
                        dataGridViewPaiment.Columns["nom_tut_carte"].HeaderText = "Nom sur Carte";
                        dataGridViewPaiment.Columns["numero_carte"].HeaderText = "Numéro Carte";
                        dataGridViewPaiment.Columns["date_expiration"].HeaderText = "Date Expiration";

                        // NOUVEAU : Configuration de la colonne code_secret
                        if (dataGridViewPaiment.Columns.Contains("code_secret"))
                        {
                            dataGridViewPaiment.Columns["code_secret"].HeaderText = "Code Secret (CVV)";
                            // Optionnel : masquer la colonne si elle est trop sensible, ou utiliser un style
                            // dataGridViewPaiment.Columns["code_secret"].Visible = false;
                        }

                        dataGridViewPaiment.Columns["email_vraie"].HeaderText = "Email Client";

                        // Ajouter les colonnes de boutons (vérification d'existence conservée)
                        if (!dataGridViewPaiment.Columns.Contains("btnAccepterColumn"))
                        {
                            DataGridViewButtonColumn btnAccepterColumn = new DataGridViewButtonColumn();
                            btnAccepterColumn.Name = "btnAccepterColumn";
                            btnAccepterColumn.HeaderText = "Accepter";
                            btnAccepterColumn.Text = "Accepter";
                            btnAccepterColumn.UseColumnTextForButtonValue = true;
                            dataGridViewPaiment.Columns.Add(btnAccepterColumn);
                        }
                        if (!dataGridViewPaiment.Columns.Contains("btnRefuserColumn"))
                        {
                            DataGridViewButtonColumn btnRefuserColumn = new DataGridViewButtonColumn();
                            btnRefuserColumn.Name = "btnRefuserColumn";
                            btnRefuserColumn.HeaderText = "Refuser";
                            btnRefuserColumn.Text = "Refuser";
                            btnRefuserColumn.UseColumnTextForButtonValue = true;
                            dataGridViewPaiment.Columns.Add(btnRefuserColumn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des paiements : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPaiment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Assurez-vous que les colonnes existent avant de tenter d'accéder à leur valeur
            if (!dataGridViewPaiment.Columns.Contains("Id_paiement") ||
                !dataGridViewPaiment.Columns.Contains("id_commande") ||
                !dataGridViewPaiment.Columns.Contains("email_vraie"))
            {
                MessageBox.Show("Erreur: Colonne essentielle manquante. Veuillez vérifier le chargement des données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idPaiement = Convert.ToInt32(dataGridViewPaiment.Rows[e.RowIndex].Cells["Id_paiement"].Value);
            int idCommande = Convert.ToInt32(dataGridViewPaiment.Rows[e.RowIndex].Cells["id_commande"].Value);
            string emailClient = dataGridViewPaiment.Rows[e.RowIndex].Cells["email_vraie"].Value != null ? dataGridViewPaiment.Rows[e.RowIndex].Cells["email_vraie"].Value.ToString() : "";

            if (e.ColumnIndex == dataGridViewPaiment.Columns["btnAccepterColumn"].Index)
            {
                try
                {
                    using (SqlConnection cnx = new SqlConnection(ConnectionString))
                    {
                        cnx.Open();
                        // Mettre à jour le statut de la commande et du paiement
                        string updateQuery = @"
                            UPDATE Commande SET statut = 'Payée' WHERE id_commande = @idCommande;
                            UPDATE Paiement SET statut_paiement = 'Réussi' WHERE Id_paiement = @idPaiement";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, cnx))
                        {
                            cmd.Parameters.AddWithValue("@idCommande", idCommande);
                            cmd.Parameters.AddWithValue("@idPaiement", idPaiement);
                            cmd.ExecuteNonQuery();
                        }

                        // Envoyer la facture par email
                        if (!string.IsNullOrEmpty(emailClient))
                        {
                            EnvoyerFactureParEmail(idPaiement, emailClient);
                        }
                        else
                        {
                            MessageBox.Show("Aucun email disponible pour envoyer la facture.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        ChargerPaiements(); // Rafraîchir la grille
                        MessageBox.Show("Paiement accepté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'acceptation : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == dataGridViewPaiment.Columns["btnRefuserColumn"].Index)
            {
                try
                {
                    using (SqlConnection cnx = new SqlConnection(ConnectionString))
                    {
                        cnx.Open();
                        // Mettre à jour le statut du paiement, laisser la commande en "En cours"
                        string updateQuery = @"
                            UPDATE Paiement SET statut_paiement = 'Refusé' WHERE Id_paiement = @idPaiement";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, cnx))
                        {
                            cmd.Parameters.AddWithValue("@idPaiement", idPaiement);
                            cmd.ExecuteNonQuery();
                        }
                        ChargerPaiements(); // Rafraîchir la grille
                        MessageBox.Show("Paiement refusé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du refus : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EnvoyerFactureParEmail(int idPaiement, string emailDestinataire)
        {
            try
            {
                // Récupérer les détails de la facture depuis la base
                DataTable factureDetails = new DataTable();
                int idCommande = 0; // Variable pour stocker l'ID de la commande
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string query = @"
                        SELECT p.Id_paiement, p.id_commande, p.montant_total, p.nom_tut_carte, p.email_vraie, p.date_paiement,
                                c.date_heure AS date_commande, b.numero_table
                        FROM Paiement p
                        INNER JOIN Commande c ON p.id_commande = c.id_commande
                        INNER JOIN Banc b ON c.id_table = b.Id_table
                        WHERE p.Id_paiement = @idPaiement";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idPaiement", idPaiement);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(factureDetails);
                        }
                    }
                }

                if (factureDetails.Rows.Count == 0)
                {
                    MessageBox.Show("Détails de la facture non trouvés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = factureDetails.Rows[0];
                string nomClient = row["nom_tut_carte"].ToString();
                decimal montantTotal = Convert.ToDecimal(row["montant_total"]);
                string dateCommande = row["date_commande"].ToString();
                string numeroTable = row["numero_table"].ToString();
                string datePaiement = row["date_paiement"].ToString();
                // Mise à jour de l'idCommande pour la requête des plats
                idCommande = Convert.ToInt32(row["id_commande"]);

                // Récupérer les détails des plats
                DataTable detailsPlats = new DataTable();
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string queryPlats = @"
                        SELECT p.nom, dc.quantite, p.prix
                        FROM DetailsCommande dc
                        INNER JOIN Plat p ON dc.id_plat = p.Id_plat
                        WHERE dc.id_commande = @idCommande";
                    using (SqlCommand cmd = new SqlCommand(queryPlats, cnx))
                    {
                        // CORRECTION : Utilisation de la variable idCommande pour récupérer les détails des plats
                        cmd.Parameters.AddWithValue("@idCommande", idCommande);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(detailsPlats);
                        }
                    }
                }

                // Construire le corps de l'email avec une facture stylée
                string emailBody = "====================================\n" +
                                    "          SAKAFO TRACKER\n" +
                                    "        FACTURE DE PAIEMENT\n" +
                                    "====================================\n\n" +
                                    "Numéro de Facture: " + idPaiement + "\n" +
                                    "Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n" +
                                    "Client: " + nomClient + "\n" +
                                    "Email: " + emailDestinataire + "\n" +
                                    "Commande: #" + idCommande + "\n" + // Utilisation de l'idCommande
                                    "Table: " + numeroTable + "\n" +
                                    "Date Commande: " + dateCommande + "\n" +
                                    "Date Paiement: " + datePaiement + "\n\n" +
                                    "------------------------------------\n" +
                                    "          DÉTAILS DES ARTICLES\n" +
                                    "------------------------------------\n";

                // Ajouter les plats
                foreach (DataRow platRow in detailsPlats.Rows)
                {
                    string nomPlat = platRow["nom"].ToString();
                    int quantite = Convert.ToInt32(platRow["quantite"]);
                    decimal prix = Convert.ToDecimal(platRow["prix"]);
                    decimal sousTotal = quantite * prix;
                    emailBody += nomPlat + " (x" + quantite + ") - " + sousTotal.ToString("N0") + " Ar\n";
                }

                emailBody += "------------------------------------\n" +
                            "Montant Total: " + montantTotal.ToString("N0") + " Ar\n" +
                            "====================================\n\n" +
                            "Merci pour votre confiance !\n" +
                            "Contactez-nous: andycedric65@gmail.com\n" +
                            "Contactez-nous: +261345737192\n" +
                            "Sakafo Tracker - Fianarantsoa, Madagascar";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SmtpUser);
                    mail.To.Add(emailDestinataire);
                    mail.Subject = "Facture de votre commande #" + idCommande;
                    mail.Body = emailBody;

                    using (SmtpClient smtp = new SmtpClient(SmtpServer, SmtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(SmtpUser, SmtpPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                MessageBox.Show("Facture envoyée avec succès à " + emailDestinataire, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi de la facture : " + ex.Message + "\nDétails : " + ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListPaiment_Load(object sender, EventArgs e)
        {

        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}