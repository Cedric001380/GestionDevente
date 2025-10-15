namespace Gestiondevente
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lblEmailouphone = new System.Windows.Forms.Label();
            this.lblMotdepasse = new System.Windows.Forms.Label();
            this.txtEmailouphone = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.lblPasencorecompte = new System.Windows.Forms.Label();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlLoginBorder = new System.Windows.Forms.Panel();
            this.pnlPasswordBorder = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.pnlLoginBorder.SuspendLayout();
            this.pnlPasswordBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmailouphone
            // 
            this.lblEmailouphone.AutoSize = true;
            this.lblEmailouphone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailouphone.ForeColor = System.Drawing.Color.Black;
            this.lblEmailouphone.Location = new System.Drawing.Point(147, 212);
            this.lblEmailouphone.Name = "lblEmailouphone";
            this.lblEmailouphone.Size = new System.Drawing.Size(174, 13);
            this.lblEmailouphone.TabIndex = 1;
            this.lblEmailouphone.Text = "Email ou Numéro du téléphone :";
            this.lblEmailouphone.Click += new System.EventHandler(this.lblEmailouphone_Click);
            // 
            // lblMotdepasse
            // 
            this.lblMotdepasse.AutoSize = true;
            this.lblMotdepasse.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotdepasse.Location = new System.Drawing.Point(147, 323);
            this.lblMotdepasse.Name = "lblMotdepasse";
            this.lblMotdepasse.Size = new System.Drawing.Size(82, 13);
            this.lblMotdepasse.TabIndex = 2;
            this.lblMotdepasse.Text = "Mot de passe :";
            this.lblMotdepasse.Click += new System.EventHandler(this.lblMotdepasse_Click);
            // 
            // txtEmailouphone
            // 
            this.txtEmailouphone.Location = new System.Drawing.Point(13, 24);
            this.txtEmailouphone.Name = "txtEmailouphone";
            this.txtEmailouphone.Size = new System.Drawing.Size(321, 20);
            this.txtEmailouphone.TabIndex = 3;
            this.txtEmailouphone.TextChanged += new System.EventHandler(this.txtEmailouphone_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(13, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(321, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.Location = new System.Drawing.Point(226, 436);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(167, 49);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "SE CONNECTER";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSignup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignup.Location = new System.Drawing.Point(226, 546);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(167, 56);
            this.btnSignup.TabIndex = 6;
            this.btnSignup.Text = "S\'INSCRIRE";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // lblPasencorecompte
            // 
            this.lblPasencorecompte.AutoSize = true;
            this.lblPasencorecompte.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasencorecompte.Location = new System.Drawing.Point(223, 512);
            this.lblPasencorecompte.Name = "lblPasencorecompte";
            this.lblPasencorecompte.Size = new System.Drawing.Size(154, 14);
            this.lblPasencorecompte.TabIndex = 7;
            this.lblPasencorecompte.Text = "Pas encore de compte?";
            this.lblPasencorecompte.Click += new System.EventHandler(this.lblPasencorecompte_Click);
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Location = new System.Drawing.Point(508, 370);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(34, 22);
            this.btnTogglePassword.TabIndex = 8;
            this.btnTogglePassword.Text = "👁️";
            this.btnTogglePassword.UseVisualStyleBackColor = true;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // lblTitre
            // 
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitre.Location = new System.Drawing.Point(290, 54);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(324, 72);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Connectez vous";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(668, -3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(311, 645);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(34, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(147, 153);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 13;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // pnlLoginBorder
            // 
            this.pnlLoginBorder.Controls.Add(this.txtEmailouphone);
            this.pnlLoginBorder.Location = new System.Drawing.Point(150, 240);
            this.pnlLoginBorder.Name = "pnlLoginBorder";
            this.pnlLoginBorder.Size = new System.Drawing.Size(370, 59);
            this.pnlLoginBorder.TabIndex = 15;
            this.pnlLoginBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLoginBorder_Paint);
            // 
            // pnlPasswordBorder
            // 
            this.pnlPasswordBorder.Controls.Add(this.txtPassword);
            this.pnlPasswordBorder.Location = new System.Drawing.Point(150, 351);
            this.pnlPasswordBorder.Name = "pnlPasswordBorder";
            this.pnlPasswordBorder.Size = new System.Drawing.Size(352, 59);
            this.pnlPasswordBorder.TabIndex = 16;
            this.pnlPasswordBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPasswordBorder_Paint);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(979, 642);
            this.Controls.Add(this.pnlPasswordBorder);
            this.Controls.Add(this.pnlLoginBorder);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnTogglePassword);
            this.Controls.Add(this.lblPasencorecompte);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblMotdepasse);
            this.Controls.Add(this.lblEmailouphone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.pnlLoginBorder.ResumeLayout(false);
            this.pnlLoginBorder.PerformLayout();
            this.pnlPasswordBorder.ResumeLayout(false);
            this.pnlPasswordBorder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmailouphone;
        private System.Windows.Forms.Label lblMotdepasse;
        private System.Windows.Forms.TextBox txtEmailouphone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label lblPasencorecompte;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel pnlLoginBorder;
        private System.Windows.Forms.Panel pnlPasswordBorder;
    }
}