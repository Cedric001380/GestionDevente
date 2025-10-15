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
    public partial class FormulaireCommande : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        private List<PlatCommande> _panier;
        private int _idTable;
        private int _idUtilisateur;

        public FormulaireCommande(List<PlatCommande> panier, int idTable, int idUtilisateur)
        {
            InitializeComponent();
            _panier = panier;
            _idTable = idTable;
            _idUtilisateur = idUtilisateur;
        }

        private void FormulaireCommande_Load(object sender, EventArgs e)
        {
            lblNumeroTable.Text = "Table n° " + _idTable.ToString();

            float total = 0;
            foreach (var plat in _panier)
            {
                lsbRecapitulatif.Items.Add(string.Format("{0} (x{1}) - {2} Ar", plat.Nom, plat.Quantite, (plat.Prix * plat.Quantite).ToString("N0")));
                total += plat.Prix * plat.Quantite;
            }

            lblTotalCommande.Text = "Total : " + total.ToString("N0") + " Ar";
        }

        private void btnEnregistrerCommande_Click(object sender, EventArgs e)
        {
            if (_panier == null || _panier.Count == 0)
            {
                MessageBox.Show("Le panier est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();

                    string queryCommande = "INSERT INTO Commande (date_heure, id_table, id_utilisateur, statut) VALUES (@date, @idTable, @idUser, @statut); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmdCommande = new SqlCommand(queryCommande, cnx))
                    {
                        cmdCommande.Parameters.AddWithValue("@date", DateTime.Now);
                        cmdCommande.Parameters.AddWithValue("@idTable", _idTable);
                        cmdCommande.Parameters.AddWithValue("@idUser", _idUtilisateur);
                        cmdCommande.Parameters.AddWithValue("@statut", "En cours");

                        int idCommande = Convert.ToInt32(cmdCommande.ExecuteScalar());

                        foreach (var plat in _panier)
                        {
                            string queryDetails = "INSERT INTO DetailsCommande (id_commande, id_plat, quantite) VALUES (@idCommande, @idPlat, @quantite)";
                            using (SqlCommand cmdDetails = new SqlCommand(queryDetails, cnx))
                            {
                                cmdDetails.Parameters.AddWithValue("@idCommande", idCommande);
                                cmdDetails.Parameters.AddWithValue("@idPlat", plat.Id_plat);
                                cmdDetails.Parameters.AddWithValue("@quantite", plat.Quantite);
                                cmdDetails.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Commande enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de la commande : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}