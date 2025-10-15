using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Gestiondevente
{
    public partial class LoginForm : Form
    {
        // Constantes de connexion
        private SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True");

        // Paramètres de style des TextBoxes (via Panels)
        private const int CornerRadius = 20; // Rayon des coins pour un look plus grand
        private const int ActiveBorderWidth = 2;
        private const int InactiveBorderWidth = 1;
        private readonly Color ActiveColor = Color.FromArgb(52, 152, 219); // Bleu vif (DodgerBlue)
        private readonly Color InactiveColor = Color.LightGray;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public LoginForm()
        {
            InitializeComponent();

            // Attachement des événements de focus pour le style des TextBoxes
            txtEmailouphone.Enter += OnTextBoxEnter;
            txtEmailouphone.Leave += OnTextBoxLeave;
            txtPassword.Enter += OnTextBoxEnter;
            txtPassword.Leave += OnTextBoxLeave;

            // Attachement des événements Paint des panels
            pnlLoginBorder.Paint += pnlBorder_Paint;
            pnlPasswordBorder.Paint += pnlBorder_Paint;

            ApplyStyles();
            MakePictureBoxRound();
            SetupPlaceholders();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.WhiteSmoke;

            // --- 1. Amélioration des Boutons et du Formulaire (inchangé) ---

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, CornerRadius, CornerRadius));

            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.BackColor = Color.Transparent;
            btnSignup.ForeColor = Color.DodgerBlue; // Couleur du lien
            btnSignup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSignup.FlatAppearance.BorderSize = 0;
            btnSignup.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSignup.Width, btnSignup.Height, CornerRadius, CornerRadius));

            // --- 2. Configuration des TextBoxes (pour le look plus grand) ---

            txtEmailouphone.BorderStyle = BorderStyle.None;
            txtEmailouphone.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtEmailouphone.BackColor = Color.WhiteSmoke; // Assurez-vous que le TextBox a la même couleur que le Panel parent
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtPassword.BackColor = Color.WhiteSmoke;

            SetPanelBorderStyle(pnlLoginBorder, InactiveBorderWidth, InactiveColor);
            SetPanelBorderStyle(pnlPasswordBorder, InactiveBorderWidth, InactiveColor);

            // --- 3. Amélioration des Labels ---

            // Titre Principal
            if (lblTitre != null)
            {
                lblTitre.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                lblTitre.ForeColor = Color.FromArgb(44, 62, 80); // Un gris foncé pour le contraste
            }

            // Labels d'étiquette de champ (Email/Mot de passe)
            // On utilise une police standard mais claire
            if (lblEmailouphone != null)
            {
                lblEmailouphone.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                lblEmailouphone.ForeColor = Color.Black;
            }
            if (lblMotdepasse != null)
            {
                lblMotdepasse.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                lblMotdepasse.ForeColor = Color.Black;
            }

            // Label de lien/info (Pas encore de compte)
            if (lblPasencorecompte != null)
            {
                lblPasencorecompte.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lblPasencorecompte.ForeColor = Color.DimGray; // Gris pour le texte d'information
            }
        }

        // --- Logique d'Amélioration des TextBoxes (via Panels) ---

        private void SetPanelBorderStyle(Panel panel, int borderWidth, Color borderColor)
        {
            if (panel == null) return;

            panel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width + 1, panel.Height + 1, CornerRadius, CornerRadius));
            panel.Tag = new Tuple<int, Color>(borderWidth, borderColor);
            panel.Invalidate();
        }

        private void pnlBorder_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null || panel.Tag == null) return;

            var borderInfo = panel.Tag as Tuple<int, Color>;
            int width = borderInfo.Item1;
            Color color = borderInfo.Item2;

            using (Pen pen = new Pen(color, width))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(width / 2, width / 2, panel.Width - width, panel.Height - width);
                GraphicsPath path = new GraphicsPath();

                path.AddArc(rect.X, rect.Y, CornerRadius * 2, CornerRadius * 2, 180, 90);
                path.AddArc(rect.Right - CornerRadius * 2, rect.Y, CornerRadius * 2, CornerRadius * 2, 270, 90);
                path.AddArc(rect.Right - CornerRadius * 2, rect.Bottom - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 90, 90);
                path.CloseFigure();

                e.Graphics.DrawPath(pen, path);
            }
        }

        private void OnTextBoxEnter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox == txtEmailouphone)
            {
                SetPanelBorderStyle(pnlLoginBorder, ActiveBorderWidth, ActiveColor);
            }
            else if (textBox == txtPassword)
            {
                SetPanelBorderStyle(pnlPasswordBorder, ActiveBorderWidth, ActiveColor);
            }

            RemovePlaceholder(sender, e);
        }

        private void OnTextBoxLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox == txtEmailouphone)
            {
                SetPanelBorderStyle(pnlLoginBorder, InactiveBorderWidth, InactiveColor);
            }
            else if (textBox == txtPassword)
            {
                SetPanelBorderStyle(pnlPasswordBorder, InactiveBorderWidth, InactiveColor);
            }

            AddPlaceholder(sender, e);
        }

        // --- Logique du Placeholder (inchangée) ---

        private void SetupPlaceholders()
        {
            txtEmailouphone.Text = "Entrez votre email ou votre numéro";
            txtEmailouphone.ForeColor = Color.Gray;

            txtPassword.Text = "Entrez votre mot de passe";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.PasswordChar = '\0';
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Entrez votre email ou votre numéro" || textBox.Text == "Entrez votre mot de passe")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
            if (textBox == txtPassword && txtPassword.Text != "")
            {
                txtPassword.PasswordChar = '●';
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtEmailouphone)
                {
                    textBox.Text = "Entrez votre email ou votre numéro";
                }
                else if (textBox == txtPassword)
                {
                    textBox.Text = "Entrez votre mot de passe";
                    txtPassword.PasswordChar = '\0';
                }
                textBox.ForeColor = Color.Gray;
            }
        }

        // --- Fonctions de base et de sécurité (inchangées) ---

        private void MakePictureBoxRound()
        {
            try
            {
                if (pictureBoxLogo.Width != pictureBoxLogo.Height)
                {
                    int size = Math.Min(pictureBoxLogo.Width, pictureBoxLogo.Height);
                    pictureBoxLogo.Size = new Size(size, size);
                }
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0, 0, pictureBoxLogo.Width - 1, pictureBoxLogo.Height - 1);
                pictureBoxLogo.Region = new Region(gp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la stylisation du logo : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginText = txtEmailouphone.Text;
            string passwordText = txtPassword.Text;

            if (string.IsNullOrEmpty(loginText) || string.IsNullOrEmpty(passwordText) ||
                loginText == "Entrez votre email ou votre numéro" || passwordText == "Entrez votre mot de passe")
            {
                MessageBox.Show("Veuillez entrer votre email/téléphone et votre mot de passe.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = GetHashString(passwordText);

            try
            {
                string query = "SELECT Id_utilisateur, role FROM Utilisateur WHERE (email = @login OR phone = @login) AND mot_de_passe = @password";
                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    cmd.Parameters.AddWithValue("@login", loginText);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string userRole = reader.GetString(1);
                            reader.Close();

                            MessageBox.Show("Connexion réussie ! Bienvenue.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();

                            if (userRole.ToLower() == "admin")
                            {
                                MenuFormAdmin menuAdminForm = new MenuFormAdmin();
                                menuAdminForm.Show();
                            }
                            else if (userRole.ToLower() == "utilisateur")
                            {
                                MenuForm menuForm = new MenuForm(userId);
                                menuForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Votre rôle n'est pas reconnu. Veuillez contacter l'administrateur.", "Erreur de rôle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email/téléphone ou mot de passe incorrect. Veuillez réessayer.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        private string GetHashString(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 signupForm = new Form1();
            signupForm.Show();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Entrez votre mot de passe") return;

            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
            }
        }

        // Événements Paint des panels
        private void pnlLoginBorder_Paint(object sender, PaintEventArgs e)
        {
            pnlBorder_Paint(sender, e);
        }

        private void pnlPasswordBorder_Paint(object sender, PaintEventArgs e)
        {
            pnlBorder_Paint(sender, e);
        }

        // Méthodes événementielles laissées vides
        private void pictureBoxLogo_Click(object sender, EventArgs e) { }
        private void txtEmailouphone_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void LoginForm_Load(object sender, EventArgs e) { }
        private void lblPasencorecompte_Click(object sender, EventArgs e) { }
        private void lblEmailouphone_Click(object sender, EventArgs e) { }
        private void lblMotdepasse_Click(object sender, EventArgs e) { }
        private void panelTitre_Paint(object sender, PaintEventArgs e) { }
        private void pictureBoxImage_Click(object sender, EventArgs e) { }
        private void lblTitre_Click(object sender, EventArgs e) { }
    }
}