using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestiondevente
{
    public partial class PaiementUtilisateur : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True"; private int idCommande; private int idUtilisateurConnecte;

        public PaiementUtilisateur(int idCommande)
        {
            InitializeComponent();
            this.idCommande = idCommande;
            ChargerDetailsCommande();
        }

        public PaiementUtilisateur()
        {
            InitializeComponent();
            this.idCommande = -1;
        }

        private void PaiementUtilisateur_Load(object sender, EventArgs e)
        {
            if (idCommande == -1)
            {
                MessageBox.Show("Aucune commande sélectionnée. Veuillez sélectionner une commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ChargerUtilisateurConnecte();
            }
        }

        private void ChargerUtilisateurConnecte()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT Id_utilisateur FROM Commande WHERE id_commande = @idCommande";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idCommande", idCommande);
                        cnx.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            idUtilisateurConnecte = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Utilisateur non trouvé pour cette commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'utilisateur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerDetailsCommande()
        {
            if (idCommande == -1) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    string query = @"
                SELECT c.id_commande, c.date_heure, b.numero_table, c.statut, 
                       SUM(dc.quantite * p.prix) as montant_total
                FROM Commande c
                INNER JOIN Banc b ON c.id_table = b.Id_table
                INNER JOIN DetailsCommande dc ON c.id_commande = dc.id_commande
                INNER JOIN Plat p ON dc.id_plat = p.Id_plat
                WHERE c.id_commande = @idCommande
                GROUP BY c.id_commande, c.date_heure, b.numero_table, c.statut";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idCommande", idCommande);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                using (SqlConnection detailsCnx = new SqlConnection(ConnectionString))
                                {
                                    detailsCnx.Open();
                                    string detailsQuery = @"
                                SELECT p.nom, dc.quantite
                                FROM DetailsCommande dc
                                INNER JOIN Plat p ON dc.id_plat = p.Id_plat
                                WHERE dc.id_commande = @idCommande";
                                    using (SqlCommand detailsCmd = new SqlCommand(detailsQuery, detailsCnx))
                                    {
                                        detailsCmd.Parameters.AddWithValue("@idCommande", idCommande);
                                        using (SqlDataReader detailsReader = detailsCmd.ExecuteReader())
                                        {
                                            List<string> detailsList = new List<string>();
                                            while (detailsReader.Read())
                                            {
                                                if (detailsReader["nom"] != DBNull.Value && detailsReader["quantite"] != DBNull.Value)
                                                {
                                                    detailsList.Add(String.Format("{0} (x{1})", detailsReader["nom"], detailsReader["quantite"]));
                                                }
                                            }
                                            string details = string.Join(", ", detailsList);
                                            lblCommandeInfo.Text = String.Format("Commande n°{0}\nDate: {1}\nTable: {2}\nStatut: {3}\nTotal: {4:N0} Ar\nDétails: {5}",
                                                reader["id_commande"], reader["date_heure"], reader["numero_table"], reader["statut"], Convert.ToSingle(reader["montant_total"]), details);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Commande non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des détails de la commande : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValiderPaiement_Click(object sender, EventArgs e)
        {
            if (idCommande == -1)
            {
                MessageBox.Show("Aucune commande sélectionnée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation des champs
            if (string.IsNullOrWhiteSpace(txtNomtutilcarte.Text))
            {
                MessageBox.Show("Veuillez entrer le nom sur la carte.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            long numeroCarte;
            if (txtNumCarte.Text.Length != 16 || !long.TryParse(txtNumCarte.Text, out numeroCarte))
            {
                MessageBox.Show("Veuillez entrer un numéro de carte valide (16 chiffres).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dateExpiration = dateTimePickerDateexpiration.Value;
            if (dateExpiration < DateTime.Now)
            {
                MessageBox.Show("Veuillez entrer une date d'expiration valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCodeSecurite.Text) || txtCodeSecurite.Text.Length != 3)
            {
                MessageBox.Show("Veuillez entrer un code de sécurité valide (3 chiffres).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtVraieEmail.Text.Contains("@") || !txtVraieEmail.Text.Contains("."))
            {
                MessageBox.Show("Veuillez entrer une adresse email valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    // Récupérer le montant total
                    string montantQuery = @"
                SELECT SUM(dc.quantite * p.prix) as montant_total
                FROM Commande c
                INNER JOIN DetailsCommande dc ON c.id_commande = dc.id_commande
                INNER JOIN Plat p ON dc.id_plat = p.Id_plat
                WHERE c.id_commande = @idCommande";
                    decimal montantTotal;
                    using (SqlCommand montantCmd = new SqlCommand(montantQuery, cnx))
                    {
                        montantCmd.Parameters.AddWithValue("@idCommande", idCommande);
                        object result = montantCmd.ExecuteScalar();
                        montantTotal = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    // Insérer dans la table Paiement avec statut "En attente"
                    string insertQuery = @"
                INSERT INTO Paiement (id_commande, id_utilisateur, date_paiement, montant_total, 
                                     nom_tut_carte, numero_carte, date_expiration, code_secret, statut_paiement, 
                                     reference_paiement, email_vraie)
                VALUES (@idCommande, @idUtilisateur, @datePaiement, @montantTotal, 
                        @nomTutCarte, @numeroCarte, @dateExpiration, @codeSecret, @statutPaiement, 
                        @referencePaiement, @emailVraie)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idCommande", idCommande);
                        cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateurConnecte);
                        cmd.Parameters.AddWithValue("@datePaiement", DateTime.Now);
                        cmd.Parameters.AddWithValue("@montantTotal", montantTotal);
                        cmd.Parameters.AddWithValue("@nomTutCarte", txtNomtutilcarte.Text);
                        cmd.Parameters.AddWithValue("@numeroCarte", numeroCarte);
                        cmd.Parameters.AddWithValue("@dateExpiration", dateExpiration);
                        cmd.Parameters.AddWithValue("@codeSecret", txtCodeSecurite.Text);
                        cmd.Parameters.AddWithValue("@statutPaiement", "En attente"); // Changé de "Réussi" à "En attente"
                        cmd.Parameters.AddWithValue("@referencePaiement", Guid.NewGuid().ToString());
                        cmd.Parameters.AddWithValue("@emailVraie", txtVraieEmail.Text);

                        cmd.ExecuteNonQuery();
                    }

                    // Ne pas mettre à jour le statut de la commande ici
                    MessageBox.Show("Paiement soumis avec succès ! En attente de validation par l'admin.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du traitement du paiement : " + ex.Message + "\nDétails : " + ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumCarte_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCodeSecurite_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNomtutilcarte_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtVraieEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void panelPaiement_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dateTimePickerDateexpiration_ValueChanged(object sender, EventArgs e)
        {
        }

        private void lblCommandeInfo_Click(object sender, EventArgs e)
        {
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnToggleCodeNomtutil_Click(object sender, EventArgs e)
        {
            if (txtCodeSecurite.PasswordChar == '●')
            {
                txtCodeSecurite.PasswordChar = '\0';
            }
            else
            {
                txtCodeSecurite.PasswordChar = '●';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNomtutilcarte.PasswordChar == '●')
            {
                txtNomtutilcarte.PasswordChar = '\0';
            }
            else
            {
                txtNomtutilcarte.PasswordChar = '●';
            }
        }
    }

}