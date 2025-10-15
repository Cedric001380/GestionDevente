namespace Gestiondevente
{
    partial class VoirCommandeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoirCommandeForm));
            this.dataGridViewCommande = new System.Windows.Forms.DataGridView();
            this.btnPayerColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCommande
            // 
            this.dataGridViewCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCommande.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnPayerColumn});
            this.dataGridViewCommande.Location = new System.Drawing.Point(249, 130);
            this.dataGridViewCommande.Name = "dataGridViewCommande";
            this.dataGridViewCommande.Size = new System.Drawing.Size(553, 248);
            this.dataGridViewCommande.TabIndex = 0;
            this.dataGridViewCommande.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCommande_CellContentClick);
            // 
            // btnPayerColumn
            // 
            this.btnPayerColumn.HeaderText = "Faire un paiement";
            this.btnPayerColumn.Name = "btnPayerColumn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(424, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liste des commandes";
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(470, 420);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(81, 35);
            this.btnRetour.TabIndex = 2;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(44, 23);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(141, 141);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 17;
            this.pictureBoxLogo.TabStop = false;
            // 
            // VoirCommandeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 497);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCommande);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoirCommandeForm";
            this.Text = "VoirCommandeForm";
            this.Load += new System.EventHandler(this.VoirCommandeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCommande;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn btnPayerColumn;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}