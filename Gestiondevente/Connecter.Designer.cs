namespace Gestiondevente
{
    partial class Connecter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connecter));
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.lblPasencorecompte = new System.Windows.Forms.Label();
            this.btnSignup = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmailouphone = new System.Windows.Forms.TextBox();
            this.lblMotdepasse = new System.Windows.Forms.Label();
            this.lblEmailouphone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(564, -1);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(359, 575);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 11;
            this.pictureBox7.TabStop = false;
            // 
            // lblTitre
            // 
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitre.Location = new System.Drawing.Point(202, 52);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(252, 55);
            this.lblTitre.TabIndex = 12;
            this.lblTitre.Text = "CONNECTEZ VOUS";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Location = new System.Drawing.Point(383, 380);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(10, 10);
            this.btnTogglePassword.TabIndex = 20;
            this.btnTogglePassword.Text = "👁️";
            this.btnTogglePassword.UseVisualStyleBackColor = true;
            // 
            // lblPasencorecompte
            // 
            this.lblPasencorecompte.AutoSize = true;
            this.lblPasencorecompte.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasencorecompte.Location = new System.Drawing.Point(128, 403);
            this.lblPasencorecompte.Name = "lblPasencorecompte";
            this.lblPasencorecompte.Size = new System.Drawing.Size(154, 14);
            this.lblPasencorecompte.TabIndex = 19;
            this.lblPasencorecompte.Text = "Pas encore de compte?";
            // 
            // btnSignup
            // 
            this.btnSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSignup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignup.Location = new System.Drawing.Point(107, 453);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(175, 50);
            this.btnSignup.TabIndex = 18;
            this.btnSignup.Text = "S\'INSCRIRE";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.Location = new System.Drawing.Point(107, 322);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(175, 49);
            this.btnLogin.TabIndex = 17;
            this.btnLogin.Text = "SE CONNECTER";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(301, 252);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtEmailouphone
            // 
            this.txtEmailouphone.Location = new System.Drawing.Point(301, 187);
            this.txtEmailouphone.Name = "txtEmailouphone";
            this.txtEmailouphone.Size = new System.Drawing.Size(214, 20);
            this.txtEmailouphone.TabIndex = 15;
            this.txtEmailouphone.TextChanged += new System.EventHandler(this.txtEmailouphone_TextChanged);
            // 
            // lblMotdepasse
            // 
            this.lblMotdepasse.AutoSize = true;
            this.lblMotdepasse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotdepasse.Location = new System.Drawing.Point(57, 255);
            this.lblMotdepasse.Name = "lblMotdepasse";
            this.lblMotdepasse.Size = new System.Drawing.Size(96, 17);
            this.lblMotdepasse.TabIndex = 14;
            this.lblMotdepasse.Text = "Mot de passe :";
            // 
            // lblEmailouphone
            // 
            this.lblEmailouphone.AutoSize = true;
            this.lblEmailouphone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailouphone.ForeColor = System.Drawing.Color.Black;
            this.lblEmailouphone.Location = new System.Drawing.Point(57, 187);
            this.lblEmailouphone.Name = "lblEmailouphone";
            this.lblEmailouphone.Size = new System.Drawing.Size(198, 17);
            this.lblEmailouphone.TabIndex = 13;
            this.lblEmailouphone.Text = "Email ou Numéro du téléphone :";
            // 
            // Connecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 579);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnTogglePassword);
            this.Controls.Add(this.lblPasencorecompte);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmailouphone);
            this.Controls.Add(this.lblMotdepasse);
            this.Controls.Add(this.lblEmailouphone);
            this.Controls.Add(this.pictureBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Connecter";
            this.Text = "Connecter";
            this.Load += new System.EventHandler(this.Connecter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Label lblPasencorecompte;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmailouphone;
        private System.Windows.Forms.Label lblMotdepasse;
        private System.Windows.Forms.Label lblEmailouphone;
    }
}