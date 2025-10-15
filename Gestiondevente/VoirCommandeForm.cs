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
    public partial class VoirCommandeForm : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True"; private int idUtilisateurConnecte;

        public VoirCommandeForm(int utilisateurId)
        {
            InitializeComponent();
            idUtilisateurConnecte = utilisateurId;
        }

        private void VoirCommandeForm_Load(object sender, EventArgs e)
        {
            ChargerCommandes();
        }

        private void ChargerCommandes()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();
                    if (cnx.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Impossible de se connecter à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = @"
                    SELECT c.id_commande, c.date_heure, b.numero_table, c.statut, 
                           SUM(dc.quantite * p.prix) as total
                    FROM Commande c
                    INNER JOIN Banc b ON c.id_table = b.Id_table
                    INNER JOIN DetailsCommande dc ON c.id_commande = dc.id_commande
                    INNER JOIN Plat p ON dc.id_plat = p.Id_plat
                    WHERE c.id_utilisateur = @idUser
                    GROUP BY c.id_commande, c.date_heure, b.numero_table, c.statut";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@idUser", idUtilisateurConnecte);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Aucune commande trouvée pour cet utilisateur.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Vérifier si dataGridViewCommande existe
                        if (dataGridViewCommande == null)
                        {
                            MessageBox.Show("Le contrôle dataGridViewCommande n'est pas initialisé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Ajouter une colonne pour les détails des plats
                        dt.Columns.Add("Details", typeof(string));

                        // Récupérer les détails des plats pour chaque commande avec une nouvelle connexion
                        foreach (DataRow row in dt.Rows)
                        {
                            int idCommande = Convert.ToInt32(row["id_commande"]);
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
                                    using (SqlDataReader reader = detailsCmd.ExecuteReader())
                                    {
                                        List<string> detailsList = new List<string>();
                                        while (reader.Read())
                                        {
                                            if (reader["nom"] != DBNull.Value && reader["quantite"] != DBNull.Value)
                                            {
                                                detailsList.Add(String.Format("{0} (x{1})", reader["nom"], reader["quantite"]));
                                            }
                                        }
                                        row["Details"] = string.Join(", ", detailsList);
                                    }
                                }
                            }
                        }

                        // Configurer le DataGridView
                        dataGridViewCommande.DataSource = dt;
                        dataGridViewCommande.Columns["id_commande"].HeaderText = "ID Commande";
                        dataGridViewCommande.Columns["date_heure"].HeaderText = "Date/Heure";
                        dataGridViewCommande.Columns["numero_table"].HeaderText = "Table";
                        dataGridViewCommande.Columns["statut"].HeaderText = "Statut";
                        dataGridViewCommande.Columns["total"].HeaderText = "Total (Ar)";
                        dataGridViewCommande.Columns["total"].DefaultCellStyle.Format = "N0";
                        dataGridViewCommande.Columns["Details"].HeaderText = "Détails des plats";

                        // Ajouter la colonne bouton
                        if (!dataGridViewCommande.Columns.Contains("btnPayerColumn"))
                        {
                            DataGridViewButtonColumn btnPayerColumn = new DataGridViewButtonColumn();
                            btnPayerColumn.Name = "btnPayerColumn";
                            btnPayerColumn.HeaderText = "Action";
                            btnPayerColumn.Text = "Payer";
                            btnPayerColumn.UseColumnTextForButtonValue = true;
                            dataGridViewCommande.Columns.Add(btnPayerColumn);
                        }

                        // Désactiver le bouton Payer pour les commandes déjà payées
                        foreach (DataGridViewRow row in dataGridViewCommande.Rows)
                        {
                            if (row.Cells["statut"].Value != null && row.Cells["statut"].Value.ToString() == "Payée")
                            {
                                row.Cells["btnPayerColumn"].Value = "Payé";
                                row.Cells["btnPayerColumn"].ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des commandes : " + ex.Message + "\nDétails : " + ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewCommande.Columns[e.ColumnIndex].Name == "btnPayerColumn")
            {
                object statutObj = dataGridViewCommande.Rows[e.RowIndex].Cells["statut"].Value;
                string statut = (statutObj != null) ? statutObj.ToString() : "";
                if (statut == "Payée")
                {
                    MessageBox.Show("Cette commande est déjà payée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int idCommande = Convert.ToInt32(dataGridViewCommande.Rows[e.RowIndex].Cells["id_commande"].Value);
                try
                {
                    PaiementUtilisateur paiementForm = new PaiementUtilisateur(idCommande);
                    paiementForm.FormClosed += (s, args) => ChargerCommandes(); // Rafraîchir après fermeture
                    paiementForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ouverture du formulaire de paiement : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}