namespace Gestiondevente
{
    partial class FormulaireCommande
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormulaireCommande));
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumeroTable = new System.Windows.Forms.Label();
            this.lblTotalCommande = new System.Windows.Forms.Label();
            this.lsbRecapitulatif = new System.Windows.Forms.ListBox();
            this.btnEnregistrerCommande = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(485, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Récapitulatif des Commandes";
            // 
            // lblNumeroTable
            // 
            this.lblNumeroTable.AutoSize = true;
            this.lblNumeroTable.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroTable.Location = new System.Drawing.Point(88, 220);
            this.lblNumeroTable.Name = "lblNumeroTable";
            this.lblNumeroTable.Size = new System.Drawing.Size(132, 17);
            this.lblNumeroTable.TabIndex = 1;
            this.lblNumeroTable.Text = "Numéro de la table :";
            // 
            // lblTotalCommande
            // 
            this.lblTotalCommande.AutoSize = true;
            this.lblTotalCommande.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalCommande.Location = new System.Drawing.Point(98, 284);
            this.lblTotalCommande.Name = "lblTotalCommande";
            this.lblTotalCommande.Size = new System.Drawing.Size(136, 17);
            this.lblTotalCommande.TabIndex = 2;
            this.lblTotalCommande.Text = "Total du commande :";
            // 
            // lsbRecapitulatif
            // 
            this.lsbRecapitulatif.FormattingEnabled = true;
            this.lsbRecapitulatif.Location = new System.Drawing.Point(694, 189);
            this.lsbRecapitulatif.Name = "lsbRecapitulatif";
            this.lsbRecapitulatif.Size = new System.Drawing.Size(202, 121);
            this.lsbRecapitulatif.TabIndex = 3;
            // 
            // btnEnregistrerCommande
            // 
            this.btnEnregistrerCommande.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEnregistrerCommande.Image = ((System.Drawing.Image)(resources.GetObject("btnEnregistrerCommande.Image")));
            this.btnEnregistrerCommande.Location = new System.Drawing.Point(149, 458);
            this.btnEnregistrerCommande.Name = "btnEnregistrerCommande";
            this.btnEnregistrerCommande.Size = new System.Drawing.Size(99, 36);
            this.btnEnregistrerCommande.TabIndex = 4;
            this.btnEnregistrerCommande.Text = "Enregistrer";
            this.btnEnregistrerCommande.UseVisualStyleBackColor = true;
            this.btnEnregistrerCommande.Click += new System.EventHandler(this.btnEnregistrerCommande_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(98)))), ((int)(((byte)(104)))));
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(426, 458);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(99, 36);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(107, 38);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(141, 141);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 30;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormulaireCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 584);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrerCommande);
            this.Controls.Add(this.lsbRecapitulatif);
            this.Controls.Add(this.lblTotalCommande);
            this.Controls.Add(this.lblNumeroTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormulaireCommande";
            this.Text = "FormulaireCommande";
            this.Load += new System.EventHandler(this.FormulaireCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumeroTable;
        private System.Windows.Forms.Label lblTotalCommande;
        private System.Windows.Forms.ListBox lsbRecapitulatif;
        private System.Windows.Forms.Button btnEnregistrerCommande;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}