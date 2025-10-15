namespace Gestiondevente
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblMotdepasse = new System.Windows.Forms.Label();
            this.lblConfirmerMotdepasse = new System.Windows.Forms.Label();
            this.txtNomutil = new System.Windows.Forms.TextBox();
            this.txtPrenomutil = new System.Windows.Forms.TextBox();
            this.txtEmailutil = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmemdp = new System.Windows.Forms.TextBox();
            this.btnSignup = new System.Windows.Forms.Button();
            this.lblVousavezcpmpte = new System.Windows.Forms.Label();
            this.btnSignin = new System.Windows.Forms.Button();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.btnToogle = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.paneltxtNomutil = new System.Windows.Forms.Panel();
            this.paneltxtPrenomutil = new System.Windows.Forms.Panel();
            this.paneltxtEmailutil = new System.Windows.Forms.Panel();
            this.paneltxtPhone = new System.Windows.Forms.Panel();
            this.paneltxtPassword = new System.Windows.Forms.Panel();
            this.paneltxtConfirmemdp = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.paneltxtNomutil.SuspendLayout();
            this.paneltxtPrenomutil.SuspendLayout();
            this.paneltxtEmailutil.SuspendLayout();
            this.paneltxtPhone.SuspendLayout();
            this.paneltxtPassword.SuspendLayout();
            this.paneltxtConfirmemdp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Créez votre compte";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(97, 179);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(44, 17);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom :";
            this.lblNom.Click += new System.EventHandler(this.lblNom_Click);
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenom.Location = new System.Drawing.Point(97, 240);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(66, 17);
            this.lblPrenom.TabIndex = 3;
            this.lblPrenom.Text = "Prénoms :";
            this.lblPrenom.Click += new System.EventHandler(this.lblPrenom_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(97, 301);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 17);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(97, 364);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(144, 17);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Numero de téléphone :";
            this.lblPhone.Click += new System.EventHandler(this.lblPhone_Click);
            // 
            // lblMotdepasse
            // 
            this.lblMotdepasse.AutoSize = true;
            this.lblMotdepasse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotdepasse.Location = new System.Drawing.Point(97, 415);
            this.lblMotdepasse.Name = "lblMotdepasse";
            this.lblMotdepasse.Size = new System.Drawing.Size(96, 17);
            this.lblMotdepasse.TabIndex = 6;
            this.lblMotdepasse.Text = "Mot de passe :";
            this.lblMotdepasse.Click += new System.EventHandler(this.lblMotdepasse_Click);
            // 
            // lblConfirmerMotdepasse
            // 
            this.lblConfirmerMotdepasse.AutoSize = true;
            this.lblConfirmerMotdepasse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmerMotdepasse.Location = new System.Drawing.Point(97, 481);
            this.lblConfirmerMotdepasse.Name = "lblConfirmerMotdepasse";
            this.lblConfirmerMotdepasse.Size = new System.Drawing.Size(192, 17);
            this.lblConfirmerMotdepasse.TabIndex = 7;
            this.lblConfirmerMotdepasse.Text = "Confirmez votre mot de passe :";
            this.lblConfirmerMotdepasse.Click += new System.EventHandler(this.lblConfirmerMotdepasse_Click);
            // 
            // txtNomutil
            // 
            this.txtNomutil.Location = new System.Drawing.Point(19, 16);
            this.txtNomutil.Name = "txtNomutil";
            this.txtNomutil.Size = new System.Drawing.Size(276, 20);
            this.txtNomutil.TabIndex = 9;
            this.txtNomutil.TextChanged += new System.EventHandler(this.txtNomutil_TextChanged);
            // 
            // txtPrenomutil
            // 
            this.txtPrenomutil.Location = new System.Drawing.Point(19, 17);
            this.txtPrenomutil.Name = "txtPrenomutil";
            this.txtPrenomutil.Size = new System.Drawing.Size(276, 20);
            this.txtPrenomutil.TabIndex = 10;
            this.txtPrenomutil.TextChanged += new System.EventHandler(this.txtPrenomutil_TextChanged);
            // 
            // txtEmailutil
            // 
            this.txtEmailutil.Location = new System.Drawing.Point(19, 14);
            this.txtEmailutil.Name = "txtEmailutil";
            this.txtEmailutil.Size = new System.Drawing.Size(276, 20);
            this.txtEmailutil.TabIndex = 11;
            this.txtEmailutil.TextChanged += new System.EventHandler(this.txtEmailutil_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(15, 13);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(276, 20);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(276, 20);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtConfirmemdp
            // 
            this.txtConfirmemdp.Location = new System.Drawing.Point(15, 12);
            this.txtConfirmemdp.Name = "txtConfirmemdp";
            this.txtConfirmemdp.PasswordChar = '●';
            this.txtConfirmemdp.Size = new System.Drawing.Size(276, 20);
            this.txtConfirmemdp.TabIndex = 14;
            this.txtConfirmemdp.TextChanged += new System.EventHandler(this.txtConfirmemdp_TextChanged);
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(324, 545);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(223, 55);
            this.btnSignup.TabIndex = 15;
            this.btnSignup.Text = "S\'INSCRIRE";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // lblVousavezcpmpte
            // 
            this.lblVousavezcpmpte.AutoSize = true;
            this.lblVousavezcpmpte.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVousavezcpmpte.Location = new System.Drawing.Point(369, 619);
            this.lblVousavezcpmpte.Name = "lblVousavezcpmpte";
            this.lblVousavezcpmpte.Size = new System.Drawing.Size(175, 17);
            this.lblVousavezcpmpte.TabIndex = 16;
            this.lblVousavezcpmpte.Text = "Vous avez déjà  un  compte?";
            this.lblVousavezcpmpte.Click += new System.EventHandler(this.lblVousavezcpmpte_Click);
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(324, 673);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(223, 52);
            this.btnSignin.TabIndex = 17;
            this.btnSignin.Text = "SE CONNECTER ";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Location = new System.Drawing.Point(647, 399);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(46, 36);
            this.btnTogglePassword.TabIndex = 18;
            this.btnTogglePassword.Text = "👁️";
            this.btnTogglePassword.UseVisualStyleBackColor = true;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // btnToogle
            // 
            this.btnToogle.FlatAppearance.BorderSize = 0;
            this.btnToogle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToogle.Location = new System.Drawing.Point(647, 458);
            this.btnToogle.Name = "btnToogle";
            this.btnToogle.Size = new System.Drawing.Size(46, 36);
            this.btnToogle.TabIndex = 19;
            this.btnToogle.Text = "👁️";
            this.btnToogle.UseVisualStyleBackColor = true;
            this.btnToogle.Click += new System.EventHandler(this.btnToogle_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(793, -1);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(342, 754);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 21;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(31, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(141, 141);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 22;
            this.pictureBoxLogo.TabStop = false;
            // 
            // paneltxtNomutil
            // 
            this.paneltxtNomutil.Controls.Add(this.txtNomutil);
            this.paneltxtNomutil.Location = new System.Drawing.Point(324, 152);
            this.paneltxtNomutil.Name = "paneltxtNomutil";
            this.paneltxtNomutil.Size = new System.Drawing.Size(315, 44);
            this.paneltxtNomutil.TabIndex = 23;
            this.paneltxtNomutil.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltxtNomutil_Paint);
            // 
            // paneltxtPrenomutil
            // 
            this.paneltxtPrenomutil.Controls.Add(this.txtPrenomutil);
            this.paneltxtPrenomutil.Location = new System.Drawing.Point(324, 210);
            this.paneltxtPrenomutil.Name = "paneltxtPrenomutil";
            this.paneltxtPrenomutil.Size = new System.Drawing.Size(315, 47);
            this.paneltxtPrenomutil.TabIndex = 24;
            this.paneltxtPrenomutil.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltxtPrenomutil_Paint);
            // 
            // paneltxtEmailutil
            // 
            this.paneltxtEmailutil.Controls.Add(this.txtEmailutil);
            this.paneltxtEmailutil.Location = new System.Drawing.Point(324, 273);
            this.paneltxtEmailutil.Name = "paneltxtEmailutil";
            this.paneltxtEmailutil.Size = new System.Drawing.Size(315, 43);
            this.paneltxtEmailutil.TabIndex = 24;
            this.paneltxtEmailutil.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltxtEmailutil_Paint);
            // 
            // paneltxtPhone
            // 
            this.paneltxtPhone.Controls.Add(this.txtPhone);
            this.paneltxtPhone.Location = new System.Drawing.Point(324, 335);
            this.paneltxtPhone.Name = "paneltxtPhone";
            this.paneltxtPhone.Size = new System.Drawing.Size(315, 46);
            this.paneltxtPhone.TabIndex = 24;
            this.paneltxtPhone.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltxtPhone_Paint);
            // 
            // paneltxtPassword
            // 
            this.paneltxtPassword.Controls.Add(this.txtPassword);
            this.paneltxtPassword.Location = new System.Drawing.Point(324, 399);
            this.paneltxtPassword.Name = "paneltxtPassword";
            this.paneltxtPassword.Size = new System.Drawing.Size(315, 47);
            this.paneltxtPassword.TabIndex = 24;
            this.paneltxtPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltxtPassword_Paint);
            // 
            // paneltxtConfirmemdp
            // 
            this.paneltxtConfirmemdp.Controls.Add(this.txtConfirmemdp);
            this.paneltxtConfirmemdp.Location = new System.Drawing.Point(324, 469);
            this.paneltxtConfirmemdp.Name = "paneltxtConfirmemdp";
            this.paneltxtConfirmemdp.Size = new System.Drawing.Size(315, 45);
            this.paneltxtConfirmemdp.TabIndex = 24;
            this.paneltxtConfirmemdp.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltxtConfirmemdp_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 751);
            this.Controls.Add(this.paneltxtConfirmemdp);
            this.Controls.Add(this.paneltxtPassword);
            this.Controls.Add(this.paneltxtPhone);
            this.Controls.Add(this.paneltxtEmailutil);
            this.Controls.Add(this.paneltxtPrenomutil);
            this.Controls.Add(this.paneltxtNomutil);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.btnToogle);
            this.Controls.Add(this.btnTogglePassword);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.lblVousavezcpmpte);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.lblConfirmerMotdepasse);
            this.Controls.Add(this.lblMotdepasse);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.paneltxtNomutil.ResumeLayout(false);
            this.paneltxtNomutil.PerformLayout();
            this.paneltxtPrenomutil.ResumeLayout(false);
            this.paneltxtPrenomutil.PerformLayout();
            this.paneltxtEmailutil.ResumeLayout(false);
            this.paneltxtEmailutil.PerformLayout();
            this.paneltxtPhone.ResumeLayout(false);
            this.paneltxtPhone.PerformLayout();
            this.paneltxtPassword.ResumeLayout(false);
            this.paneltxtPassword.PerformLayout();
            this.paneltxtConfirmemdp.ResumeLayout(false);
            this.paneltxtConfirmemdp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblMotdepasse;
        private System.Windows.Forms.Label lblConfirmerMotdepasse;
        private System.Windows.Forms.TextBox txtNomutil;
        private System.Windows.Forms.TextBox txtPrenomutil;
        private System.Windows.Forms.TextBox txtEmailutil;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmemdp;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label lblVousavezcpmpte;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Button btnToogle;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel paneltxtNomutil;
        private System.Windows.Forms.Panel paneltxtPrenomutil;
        private System.Windows.Forms.Panel paneltxtEmailutil;
        private System.Windows.Forms.Panel paneltxtPhone;
        private System.Windows.Forms.Panel paneltxtPassword;
        private System.Windows.Forms.Panel paneltxtConfirmemdp;
    }
}

