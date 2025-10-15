namespace Gestiondevente
{
    partial class AfficherCommande
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbCommandes = new System.Windows.Forms.ListBox();
            this.dgvDetailsCommande = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsCommande)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(345, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste de commande";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mes commandes :";
            // 
            // lsbCommandes
            // 
            this.lsbCommandes.FormattingEnabled = true;
            this.lsbCommandes.Location = new System.Drawing.Point(435, 147);
            this.lsbCommandes.Name = "lsbCommandes";
            this.lsbCommandes.Size = new System.Drawing.Size(293, 134);
            this.lsbCommandes.TabIndex = 2;
            this.lsbCommandes.SelectedIndexChanged += new System.EventHandler(this.lsbCommandes_SelectedIndexChanged);
            // 
            // dgvDetailsCommande
            // 
            this.dgvDetailsCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailsCommande.Location = new System.Drawing.Point(416, 303);
            this.dgvDetailsCommande.Name = "dgvDetailsCommande";
            this.dgvDetailsCommande.Size = new System.Drawing.Size(485, 166);
            this.dgvDetailsCommande.TabIndex = 3;
            this.dgvDetailsCommande.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailsCommande_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 100);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 544);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 73);
            this.panel2.TabIndex = 5;
            // 
            // AfficherCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 617);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetailsCommande);
            this.Controls.Add(this.lsbCommandes);
            this.Controls.Add(this.label2);
            this.Name = "AfficherCommande";
            this.Text = "AfficherCommande";
            this.Load += new System.EventHandler(this.AfficherCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsCommande)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbCommandes;
        private System.Windows.Forms.DataGridView dgvDetailsCommande;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}