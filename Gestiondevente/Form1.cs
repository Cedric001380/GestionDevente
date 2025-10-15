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
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Gestiondevente
{
    public partial class Form1 : Form
    {
        // Constantes de connexion
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Cedric\Documents\Visual Studio 2012\Projects\Gestiondevente\Gestiondevente\BdGestionvente.mdf;Integrated Security=True";

        // --- Paramètres de style des TextBoxes (via Panels) ---
        private const int CornerRadius = 20;
        private const int ActiveBorderWidth = 2;
        private const int InactiveBorderWidth = 1;
        private readonly Color ActiveColor = Color.FromArgb(52, 152, 219); // Bleu vif
        private readonly Color InactiveColor = Color.LightGray;

        // --- Chaînes de Placeholder ---
        private const string PlaceholderNom = "Entrez votre nom";
        private const string PlaceholderPrenom = "Entrez votre prénom";
        private const string PlaceholderEmail = "Entrez votre adresse email";
        private const string PlaceholderPhone = "Entrez votre numéro de téléphone (ex: 032xxxxxxx)";
        private const string PlaceholderPassword = "Créez un mot de passe (min. 8 caractères)";
        private const string PlaceholderConfirmMdp = "Confirmez votre mot de passe";


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Form1()
        {
            InitializeComponent();
            SetupPlaceholders(); // Initialisation des placeholders
            AttachEventHandlers();
            ApplyStyles();
        }

        private void AttachEventHandlers()
        {
            // Attachement des événements de focus pour le style des TextBoxes et les Placeholders
            txtNomutil.Enter += OnTextBoxEnter;
            txtNomutil.Leave += OnTextBoxLeave;
            txtNomutil.Enter += RemovePlaceholder;
            txtNomutil.Leave += AddPlaceholder;

            txtPrenomutil.Enter += OnTextBoxEnter;
            txtPrenomutil.Leave += OnTextBoxLeave;
            txtPrenomutil.Enter += RemovePlaceholder;
            txtPrenomutil.Leave += AddPlaceholder;

            txtEmailutil.Enter += OnTextBoxEnter;
            txtEmailutil.Leave += OnTextBoxLeave;
            txtEmailutil.Enter += RemovePlaceholder;
            txtEmailutil.Leave += AddPlaceholder;

            txtPhone.Enter += OnTextBoxEnter;
            txtPhone.Leave += OnTextBoxLeave;
            txtPhone.Enter += RemovePlaceholder;
            txtPhone.Leave += AddPlaceholder;

            txtPassword.Enter += OnTextBoxEnter;
            txtPassword.Leave += OnTextBoxLeave;
            txtPassword.Enter += RemovePlaceholder;
            txtPassword.Leave += AddPlaceholder;

            txtConfirmemdp.Enter += OnTextBoxEnter;
            txtConfirmemdp.Leave += OnTextBoxLeave;
            txtConfirmemdp.Enter += RemovePlaceholder;
            txtConfirmemdp.Leave += AddPlaceholder;

            // Attachement de la méthode de dessin aux événements Paint des Panels
            paneltxtNomutil.Paint += pnlBorder_Paint;
            paneltxtPrenomutil.Paint += pnlBorder_Paint;
            paneltxtEmailutil.Paint += pnlBorder_Paint;
            paneltxtPhone.Paint += pnlBorder_Paint;
            paneltxtPassword.Paint += pnlBorder_Paint;
            paneltxtConfirmemdp.Paint += pnlBorder_Paint;
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // --- 1. Stylisation des TextBoxes et Panels de Bordure ---

            TextBox[] textboxes = { txtNomutil, txtPrenomutil, txtEmailutil, txtPhone, txtPassword, txtConfirmemdp };
            foreach (var txt in textboxes)
            {
                txt.BorderStyle = BorderStyle.None;
                txt.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                txt.BackColor = Color.WhiteSmoke;
            }

            Panel[] panels = { paneltxtNomutil, paneltxtPrenomutil, paneltxtEmailutil, paneltxtPhone, paneltxtPassword, paneltxtConfirmemdp };
            foreach (var pnl in panels)
            {
                SetPanelBorderStyle(pnl, InactiveBorderWidth, InactiveColor);
            }

            // --- 2. Stylisation des Labels ---

            Color fieldLabelColor = Color.FromArgb(70, 70, 70);

            if (label1 != null) // Titre Principal
            {
                label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                label1.ForeColor = Color.FromArgb(44, 62, 80);
                label1.TextAlign = ContentAlignment.MiddleCenter;
            }

            Label[] fieldLabels = { lblNom, lblPrenom, lblEmail, lblPhone, lblMotdepasse, lblConfirmerMotdepasse };
            foreach (var lbl in fieldLabels)
            {
                if (lbl != null)
                {
                    lbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    lbl.ForeColor = fieldLabelColor;
                }
            }

            if (lblVousavezcpmpte != null) // Label de lien/info
            {
                lblVousavezcpmpte.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lblVousavezcpmpte.ForeColor = Color.DimGray;
            }

            // --- 3. Stylisation des Boutons ---

            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.BackColor = Color.DodgerBlue;
            btnSignup.ForeColor = Color.White;
            btnSignup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSignup.FlatAppearance.BorderSize = 0;
            btnSignup.Cursor = Cursors.Hand;
            btnSignup.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSignup.Width, btnSignup.Height, CornerRadius, CornerRadius));

            btnSignin.FlatStyle = FlatStyle.Flat;
            btnSignin.BackColor = Color.Transparent;
            btnSignin.ForeColor = Color.DodgerBlue;
            btnSignin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSignin.FlatAppearance.BorderSize = 0;
            btnSignin.Cursor = Cursors.Hand;
            btnSignin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSignin.Width, btnSignin.Height, CornerRadius, CornerRadius));

            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.BackColor = Color.Transparent;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.Cursor = Cursors.Hand;

            btnToogle.FlatStyle = FlatStyle.Flat;
            btnToogle.BackColor = Color.Transparent;
            btnToogle.FlatAppearance.BorderSize = 0;
            btnToogle.Cursor = Cursors.Hand;
        }

        // --------------------------------------------------------------------------------------------------
        // --- Logique du Placeholder (Inchangée) ---
        // --------------------------------------------------------------------------------------------------

        private void SetupPlaceholders()
        {
            txtNomutil.Text = PlaceholderNom;
            txtNomutil.ForeColor = Color.Gray;

            txtPrenomutil.Text = PlaceholderPrenom;
            txtPrenomutil.ForeColor = Color.Gray;

            txtEmailutil.Text = PlaceholderEmail;
            txtEmailutil.ForeColor = Color.Gray;

            txtPhone.Text = PlaceholderPhone;
            txtPhone.ForeColor = Color.Gray;

            txtPassword.Text = PlaceholderPassword;
            txtPassword.ForeColor = Color.Gray;
            txtPassword.PasswordChar = '\0'; // Ne pas masquer le placeholder

            txtConfirmemdp.Text = PlaceholderConfirmMdp;
            txtConfirmemdp.ForeColor = Color.Gray;
            txtConfirmemdp.PasswordChar = '\0'; // Ne pas masquer le placeholder
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholderText = GetPlaceholderText(textBox);

            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;

                // Masquer le mot de passe seulement si le champ est celui du mot de passe
                if (textBox == txtPassword || textBox == txtConfirmemdp)
                {
                    textBox.PasswordChar = '●';
                }
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholderText = GetPlaceholderText(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;

                // Afficher le texte d'aide si le champ est vide
                if (textBox == txtPassword || textBox == txtConfirmemdp)
                {
                    textBox.PasswordChar = '\0';
                }
            }
        }

        private string GetPlaceholderText(TextBox textBox)
        {
            if (textBox == txtNomutil) return PlaceholderNom;
            if (textBox == txtPrenomutil) return PlaceholderPrenom;
            if (textBox == txtEmailutil) return PlaceholderEmail;
            if (textBox == txtPhone) return PlaceholderPhone;
            if (textBox == txtPassword) return PlaceholderPassword;
            if (textBox == txtConfirmemdp) return PlaceholderConfirmMdp;
            return string.Empty;
        }

        // --------------------------------------------------------------------------------------------------
        // --- Logique de Dessin des TextBoxes Améliorés (Inchangée) ---
        // --------------------------------------------------------------------------------------------------

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
            Panel parentPanel = textBox.Parent as Panel;

            if (parentPanel != null)
            {
                SetPanelBorderStyle(parentPanel, ActiveBorderWidth, ActiveColor);
            }
        }

        private void OnTextBoxLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Panel parentPanel = textBox.Parent as Panel;

            if (parentPanel != null)
            {
                SetPanelBorderStyle(parentPanel, InactiveBorderWidth, InactiveColor);
            }
        }

        // --------------------------------------------------------------------------------------------------
        // --- Logique d'Inscription et de Sécurité (Mise à jour pour vérifier le téléphone) ---
        // --------------------------------------------------------------------------------------------------

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Vérification des placeholders avant la validation
            if (txtNomutil.Text == PlaceholderNom) txtNomutil.Text = "";
            if (txtPrenomutil.Text == PlaceholderPrenom) txtPrenomutil.Text = "";
            if (txtEmailutil.Text == PlaceholderEmail) txtEmailutil.Text = "";
            if (txtPhone.Text == PlaceholderPhone) txtPhone.Text = "";

            // Validation des champs de saisie
            if (string.IsNullOrWhiteSpace(txtNomutil.Text) || string.IsNullOrWhiteSpace(txtPrenomutil.Text) ||
                string.IsNullOrWhiteSpace(txtEmailutil.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmemdp.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation du format d'email
            try
            {
                var addr = new MailAddress(txtEmailutil.Text);
            }
            catch
            {
                MessageBox.Show("Le format de l'adresse e-mail n'est pas valide.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation de la longueur du mot de passe (au moins 8 caractères)
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 8 caractères.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérification de la correspondance des mots de passe
            if (txtPassword.Text != txtConfirmemdp.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation du format du numéro de téléphone de Madagascar
            // Exemple de format : +261XXXXXXXXX ou 0XXXXXXXXX (9 chiffres après l'indicatif/le zéro)
            if (!Regex.IsMatch(txtPhone.Text, @"^(\+261|0)\d{9}$"))
            {
                MessageBox.Show("Le numéro de téléphone n'est pas valide. Format attendu : +261XXXXXXXXX ou 0XXXXXXXXX.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = GetHashString(txtPassword.Text);

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConnectionString))
                {
                    cnx.Open();

                    // 1. Vérifier si l'email OU le téléphone existe déjà
                    string checkUserQuery = "SELECT COUNT(*) FROM Utilisateur WHERE email = @email OR phone = @phone";
                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, cnx))
                    {
                        checkCmd.Parameters.AddWithValue("@email", txtEmailutil.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());

                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // Si un conflit existe, vérifier s'il s'agit de l'email
                            string checkEmailQuery = "SELECT COUNT(*) FROM Utilisateur WHERE email = @email";
                            using (SqlCommand checkEmailCmd = new SqlCommand(checkEmailQuery, cnx))
                            {
                                checkEmailCmd.Parameters.AddWithValue("@email", txtEmailutil.Text.Trim());
                                if ((int)checkEmailCmd.ExecuteScalar() > 0)
                                {
                                    MessageBox.Show("Cet email est déjà utilisé. Veuillez en choisir un autre.", "Inscription impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // Si ce n'était pas l'email, c'est que le téléphone est déjà pris
                            MessageBox.Show("Ce numéro de téléphone est déjà utilisé. Veuillez en choisir un autre.", "Inscription impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2. Procéder à l'insertion
                    string insertQuery = "INSERT INTO Utilisateur (nom, prenom, role, email, mot_de_passe, phone) VALUES (@nom, @prenom, @role, @email, @password, @phone)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNomutil.Text.Trim());
                        cmd.Parameters.AddWithValue("@prenom", txtPrenomutil.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", "utilisateur");
                        cmd.Parameters.AddWithValue("@email", txtEmailutil.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());

                        cmd.ExecuteNonQuery(); // Utilise la connexion déjà ouverte
                    }

                    MessageBox.Show("Inscription réussie ! Vous pouvez maintenant vous connecter.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    // Assurez-vous d'avoir un Formulaire de connexion nommé 'LoginForm'
                    Form loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur de base de données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSignin_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Assurez-vous d'avoir un Formulaire de connexion nommé 'LoginForm'
            Form loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            // Ne pas masquer/afficher si le placeholder est affiché
            if (txtPassword.Text == PlaceholderPassword) return;

            txtPassword.PasswordChar = txtPassword.PasswordChar == '●' ? '\0' : '●';
        }

        private void btnToogle_Click(object sender, EventArgs e)
        {
            // Ne pas masquer/afficher si le placeholder est affiché
            if (txtConfirmemdp.Text == PlaceholderConfirmMdp) return;

            txtConfirmemdp.PasswordChar = txtConfirmemdp.PasswordChar == '●' ? '\0' : '●';
        }

        // --- Méthodes d'événements des Panels ---
        private void paneltxtNomutil_Paint(object sender, PaintEventArgs e) { pnlBorder_Paint(sender, e); }
        private void paneltxtPrenomutil_Paint(object sender, PaintEventArgs e) { pnlBorder_Paint(sender, e); }
        private void paneltxtEmailutil_Paint(object sender, PaintEventArgs e) { pnlBorder_Paint(sender, e); }
        private void paneltxtPhone_Paint(object sender, PaintEventArgs e) { pnlBorder_Paint(sender, e); }
        private void paneltxtPassword_Paint(object sender, PaintEventArgs e) { pnlBorder_Paint(sender, e); }
        private void paneltxtConfirmemdp_Paint(object sender, PaintEventArgs e) { pnlBorder_Paint(sender, e); }

        // --- Méthodes d'événements laissées vides (nettoyage) ---
        private void txtNomutil_TextChanged(object sender, EventArgs e) { }
        private void txtPrenomutil_TextChanged(object sender, EventArgs e) { }
        private void txtEmailutil_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void txtConfirmemdp_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblVousavezcpmpte_Click(object sender, EventArgs e) { }
        private void lblNom_Click(object sender, EventArgs e) { }
        private void lblPrenom_Click(object sender, EventArgs e) { }
        private void lblEmail_Click(object sender, EventArgs e) { }
        private void lblPhone_Click(object sender, EventArgs e) { }
        private void lblMotdepasse_Click(object sender, EventArgs e) { }
        private void lblConfirmerMotdepasse_Click(object sender, EventArgs e) { }
    }
}