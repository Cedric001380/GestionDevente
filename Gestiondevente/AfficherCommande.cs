using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestiondevente
{
    public partial class AfficherCommande : Form
    {
        // Chaîne de connexion à votre base de données
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        public AfficherCommande()
        {
            InitializeComponent();
        }

        private void AfficherCommande_Load(object sender, EventArgs e)
        {
            // Appelle la méthode pour charger la liste des commandes dès l'ouverture du formulaire
            ChargerCommandes();
        }

        private void ChargerCommandes()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    // Sélectionnez les commandes qui sont "En cours"
                    string query = "SELECT Id_commande, id_table, statut, date_heure FROM Commande WHERE statut = 'En cours' ORDER BY date_heure DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Lie la ListBox aux données de la base de données
                    lsbCommandes.DataSource = dt;
                    lsbCommandes.DisplayMember = "Id_commande"; // Affiche l'ID de la commande
                    lsbCommandes.ValueMember = "Id_commande"; // La valeur de chaque élément est son ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des commandes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsbCommandes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vérifier si un élément est sélectionné et si sa valeur n'est pas null
            if (lsbCommandes.SelectedValue != null && lsbCommandes.SelectedValue is int)
            {
                // Récupérer l'ID de la commande sélectionnée en toute sécurité
                int idCommande = (int)lsbCommandes.SelectedValue;
                AfficherDetailsCommande(idCommande);
            }
            // Si la valeur est null ou n'est pas un int, ne rien faire pour éviter l'erreur.
            // (Par exemple, au premier chargement du formulaire ou si la sélection est effacée)
        }

        private void AfficherDetailsCommande(int idCommande)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    // Jointure des tables pour obtenir le nom du plat, la quantité et le prix total par plat
                    string query = "SELECT p.nom AS Plat, d.quantite AS Quantité, (p.prix * d.quantite) AS Total_Plat " +
                                   "FROM DetailsCommande d " +
                                   "JOIN Plat p ON d.id_plat = p.Id_plat " +
                                   "WHERE d.id_commande = @idCommande";

                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@idCommande", idCommande);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Affiche les détails dans le DataGridView
                    dgvDetailsCommande.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'affichage des détails de la commande : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetailsCommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cette méthode est un événement par défaut, pas besoin de la modifier pour l'instant
        }
    }
}