namespace Gestiondevente
{
    partial class PlatAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlatAdminForm));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnChoisirImage = new System.Windows.Forms.Button();
            this.btnSupprimerColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnModifierColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvPlat = new System.Windows.Forms.DataGridView();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.panelChamp = new System.Windows.Forms.Panel();
            this.btnMiseAjour = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.pbImagePlat = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbbCategorie = new System.Windows.Forms.ComboBox();
            this.txtPrixPlat = new System.Windows.Forms.TextBox();
            this.txtNomPlat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlat)).BeginInit();
            this.panelChamp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePlat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(477, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion des plats";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(97, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(131, 132);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 19;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // txtRechercher
            // 
            this.txtRechercher.Location = new System.Drawing.Point(790, 180);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(252, 20);
            this.txtRechercher.TabIndex = 11;
            this.txtRechercher.TextChanged += new System.EventHandler(this.txtRechercher_TextChanged);
            // 
            // btnRechercher
            // 
            this.btnRechercher.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Image = ((System.Drawing.Image)(resources.GetObject("btnRechercher.Image")));
            this.btnRechercher.Location = new System.Drawing.Point(1110, 168);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(121, 42);
            this.btnRechercher.TabIndex = 12;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // btnChoisirImage
            // 
            this.btnChoisirImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnChoisirImage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoisirImage.ForeColor = System.Drawing.Color.White;
            this.btnChoisirImage.Location = new System.Drawing.Point(570, 380);
            this.btnChoisirImage.Name = "btnChoisirImage";
            this.btnChoisirImage.Size = new System.Drawing.Size(75, 42);
            this.btnChoisirImage.TabIndex = 16;
            this.btnChoisirImage.Text = "Choisir";
            this.btnChoisirImage.UseVisualStyleBackColor = false;
            this.btnChoisirImage.Click += new System.EventHandler(this.btnChoisirImage_Click);
            // 
            // btnSupprimerColumn
            // 
            this.btnSupprimerColumn.HeaderText = "Supprimer";
            this.btnSupprimerColumn.Name = "btnSupprimerColumn";
            // 
            // btnModifierColumn
            // 
            this.btnModifierColumn.HeaderText = "Modifier";
            this.btnModifierColumn.Name = "btnModifierColumn";
            // 
            // dgvPlat
            // 
            this.dgvPlat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnModifierColumn,
            this.btnSupprimerColumn});
            this.dgvPlat.Location = new System.Drawing.Point(737, 235);
            this.dgvPlat.Name = "dgvPlat";
            this.dgvPlat.Size = new System.Drawing.Size(520, 200);
            this.dgvPlat.TabIndex = 17;
            this.dgvPlat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlat_CellClick);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(98)))), ((int)(((byte)(104)))));
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(952, 505);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(121, 42);
            this.btnAnnuler.TabIndex = 18;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // panelChamp
            // 
            this.panelChamp.Controls.Add(this.btnMiseAjour);
            this.panelChamp.Controls.Add(this.btnAjouter);
            this.panelChamp.Controls.Add(this.pbImagePlat);
            this.panelChamp.Controls.Add(this.txtDescription);
            this.panelChamp.Controls.Add(this.cbbCategorie);
            this.panelChamp.Controls.Add(this.btnChoisirImage);
            this.panelChamp.Controls.Add(this.txtPrixPlat);
            this.panelChamp.Controls.Add(this.txtNomPlat);
            this.panelChamp.Controls.Add(this.label6);
            this.panelChamp.Controls.Add(this.label5);
            this.panelChamp.Controls.Add(this.label4);
            this.panelChamp.Controls.Add(this.label3);
            this.panelChamp.Controls.Add(this.label2);
            this.panelChamp.Location = new System.Drawing.Point(51, 150);
            this.panelChamp.Name = "panelChamp";
            this.panelChamp.Size = new System.Drawing.Size(662, 608);
            this.panelChamp.TabIndex = 20;
            this.panelChamp.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChamp_Paint);
            // 
            // btnMiseAjour
            // 
            this.btnMiseAjour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnMiseAjour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiseAjour.ForeColor = System.Drawing.Color.White;
            this.btnMiseAjour.Location = new System.Drawing.Point(431, 532);
            this.btnMiseAjour.Name = "btnMiseAjour";
            this.btnMiseAjour.Size = new System.Drawing.Size(121, 42);
            this.btnMiseAjour.TabIndex = 25;
            this.btnMiseAjour.Text = "Mise à jour";
            this.btnMiseAjour.UseVisualStyleBackColor = false;
            this.btnMiseAjour.Click += new System.EventHandler(this.btnMiseAjour_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(203, 532);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(121, 42);
            this.btnAjouter.TabIndex = 24;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click_1);
            // 
            // pbImagePlat
            // 
            this.pbImagePlat.Location = new System.Drawing.Point(312, 330);
            this.pbImagePlat.Name = "pbImagePlat";
            this.pbImagePlat.Size = new System.Drawing.Size(252, 153);
            this.pbImagePlat.TabIndex = 23;
            this.pbImagePlat.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(312, 193);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(252, 76);
            this.txtDescription.TabIndex = 22;
            // 
            // cbbCategorie
            // 
            this.cbbCategorie.FormattingEnabled = true;
            this.cbbCategorie.Items.AddRange(new object[] {
            "Entrées",
            "Plats principaux",
            "Desserts",
            "Accompagnements",
            " Boissons"});
            this.cbbCategorie.Location = new System.Drawing.Point(312, 140);
            this.cbbCategorie.Name = "cbbCategorie";
            this.cbbCategorie.Size = new System.Drawing.Size(252, 21);
            this.cbbCategorie.TabIndex = 21;
            // 
            // txtPrixPlat
            // 
            this.txtPrixPlat.Location = new System.Drawing.Point(312, 98);
            this.txtPrixPlat.Name = "txtPrixPlat";
            this.txtPrixPlat.Size = new System.Drawing.Size(252, 20);
            this.txtPrixPlat.TabIndex = 20;
            // 
            // txtNomPlat
            // 
            this.txtNomPlat.Location = new System.Drawing.Point(312, 55);
            this.txtNomPlat.Name = "txtNomPlat";
            this.txtNomPlat.Size = new System.Drawing.Size(252, 20);
            this.txtNomPlat.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Image du plat :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Déscription :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Categorie :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Prix du plat :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nom du plat :";
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(921, 716);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(121, 42);
            this.btnRetour.TabIndex = 21;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // PlatAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 842);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.panelChamp);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.dgvPlat);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.txtRechercher);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlatAdminForm";
            this.Text = "PlatAdminForm";
            this.Load += new System.EventHandler(this.PlatAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlat)).EndInit();
            this.panelChamp.ResumeLayout(false);
            this.panelChamp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePlat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button btnChoisirImage;
        private System.Windows.Forms.DataGridViewButtonColumn btnSupprimerColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnModifierColumn;
        private System.Windows.Forms.DataGridView dgvPlat;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Panel panelChamp;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.PictureBox pbImagePlat;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbbCategorie;
        private System.Windows.Forms.TextBox txtPrixPlat;
        private System.Windows.Forms.TextBox txtNomPlat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMiseAjour;
        private System.Windows.Forms.Button btnRetour;
    }
}