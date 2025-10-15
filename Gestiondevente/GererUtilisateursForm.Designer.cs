namespace Gestiondevente
{
    partial class GererUtilisateursForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GererUtilisateursForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListeUtilisateur = new System.Windows.Forms.DataGridView();
            this.btnModifierColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSupprimerColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtConfirmemdp = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmailutil = new System.Windows.Forms.TextBox();
            this.txtPrenomutil = new System.Windows.Forms.TextBox();
            this.txtNomutil = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAjouterAdmin = new System.Windows.Forms.Button();
            this.btnMiseAjour = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeUtilisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(579, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste des Clients";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1001, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Les clients :";
            // 
            // dgvListeUtilisateur
            // 
            this.dgvListeUtilisateur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeUtilisateur.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnModifierColumn,
            this.btnSupprimerColumn});
            this.dgvListeUtilisateur.Location = new System.Drawing.Point(642, 147);
            this.dgvListeUtilisateur.Name = "dgvListeUtilisateur";
            this.dgvListeUtilisateur.Size = new System.Drawing.Size(660, 216);
            this.dgvListeUtilisateur.TabIndex = 3;
            this.dgvListeUtilisateur.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListeUtilisateur_CellContentClick);
            // 
            // btnModifierColumn
            // 
            this.btnModifierColumn.HeaderText = "Modifier";
            this.btnModifierColumn.Name = "btnModifierColumn";
            // 
            // btnSupprimerColumn
            // 
            this.btnSupprimerColumn.HeaderText = "Supprimer";
            this.btnSupprimerColumn.Name = "btnSupprimerColumn";
            // 
            // txtConfirmemdp
            // 
            this.txtConfirmemdp.Location = new System.Drawing.Point(306, 446);
            this.txtConfirmemdp.Name = "txtConfirmemdp";
            this.txtConfirmemdp.Size = new System.Drawing.Size(276, 20);
            this.txtConfirmemdp.TabIndex = 26;
            this.txtConfirmemdp.TextChanged += new System.EventHandler(this.txtConfirmemdp_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(306, 380);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(276, 20);
            this.txtPassword.TabIndex = 25;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(306, 329);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(276, 20);
            this.txtPhone.TabIndex = 24;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // txtEmailutil
            // 
            this.txtEmailutil.Location = new System.Drawing.Point(306, 265);
            this.txtEmailutil.Name = "txtEmailutil";
            this.txtEmailutil.Size = new System.Drawing.Size(276, 20);
            this.txtEmailutil.TabIndex = 23;
            this.txtEmailutil.TextChanged += new System.EventHandler(this.txtEmailutil_TextChanged);
            // 
            // txtPrenomutil
            // 
            this.txtPrenomutil.Location = new System.Drawing.Point(309, 218);
            this.txtPrenomutil.Name = "txtPrenomutil";
            this.txtPrenomutil.Size = new System.Drawing.Size(276, 20);
            this.txtPrenomutil.TabIndex = 22;
            this.txtPrenomutil.TextChanged += new System.EventHandler(this.txtPrenomutil_TextChanged);
            // 
            // txtNomutil
            // 
            this.txtNomutil.Location = new System.Drawing.Point(306, 163);
            this.txtNomutil.Name = "txtNomutil";
            this.txtNomutil.Size = new System.Drawing.Size(276, 20);
            this.txtNomutil.TabIndex = 21;
            this.txtNomutil.TextChanged += new System.EventHandler(this.txtNomutil_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Confirmez votre mot de passe :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(51, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mot de passe :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Numero de téléphone :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Prénoms :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(51, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nom :";
            // 
            // btnAjouterAdmin
            // 
            this.btnAjouterAdmin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAjouterAdmin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAjouterAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAjouterAdmin.Location = new System.Drawing.Point(123, 517);
            this.btnAjouterAdmin.Name = "btnAjouterAdmin";
            this.btnAjouterAdmin.Size = new System.Drawing.Size(141, 43);
            this.btnAjouterAdmin.TabIndex = 27;
            this.btnAjouterAdmin.Text = "Ajouter un admin";
            this.btnAjouterAdmin.UseVisualStyleBackColor = false;
            this.btnAjouterAdmin.Click += new System.EventHandler(this.btnAjouterAdmin_Click);
            // 
            // btnMiseAjour
            // 
            this.btnMiseAjour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnMiseAjour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMiseAjour.ForeColor = System.Drawing.Color.White;
            this.btnMiseAjour.Location = new System.Drawing.Point(444, 517);
            this.btnMiseAjour.Name = "btnMiseAjour";
            this.btnMiseAjour.Size = new System.Drawing.Size(141, 43);
            this.btnMiseAjour.TabIndex = 28;
            this.btnMiseAjour.Text = "Mettre à jour";
            this.btnMiseAjour.UseVisualStyleBackColor = false;
            this.btnMiseAjour.Click += new System.EventHandler(this.btnMiseAjour_Click_1);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(82, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(141, 141);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 29;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(811, 517);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(122, 40);
            this.btnRetour.TabIndex = 30;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // GererUtilisateursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 611);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnMiseAjour);
            this.Controls.Add(this.btnAjouterAdmin);
            this.Controls.Add(this.txtConfirmemdp);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmailutil);
            this.Controls.Add(this.txtPrenomutil);
            this.Controls.Add(this.txtNomutil);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvListeUtilisateur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GererUtilisateursForm";
            this.Text = "GererUtilisateursForm";
            this.Load += new System.EventHandler(this.GererUtilisateursForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeUtilisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListeUtilisateur;
        private System.Windows.Forms.TextBox txtConfirmemdp;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmailutil;
        private System.Windows.Forms.TextBox txtPrenomutil;
        private System.Windows.Forms.TextBox txtNomutil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAjouterAdmin;
        private System.Windows.Forms.DataGridViewButtonColumn btnModifierColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnSupprimerColumn;
        private System.Windows.Forms.Button btnMiseAjour;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnRetour;
    }
}