namespace Gestiondevente
{
    partial class ListCommandes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCommandes));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            this.pbLogochef = new System.Windows.Forms.PictureBox();
            this.btnSupprimerColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogochef)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste des Commandes";
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSupprimerColumn});
            this.dgvCommandes.Location = new System.Drawing.Point(271, 161);
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.Size = new System.Drawing.Size(454, 167);
            this.dgvCommandes.TabIndex = 1;
            this.dgvCommandes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommandes_CellContentClick);
            // 
            // pbLogochef
            // 
            this.pbLogochef.Image = ((System.Drawing.Image)(resources.GetObject("pbLogochef.Image")));
            this.pbLogochef.Location = new System.Drawing.Point(87, 21);
            this.pbLogochef.Name = "pbLogochef";
            this.pbLogochef.Size = new System.Drawing.Size(117, 116);
            this.pbLogochef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogochef.TabIndex = 4;
            this.pbLogochef.TabStop = false;
            // 
            // btnSupprimerColumn
            // 
            this.btnSupprimerColumn.HeaderText = "Supprimer";
            this.btnSupprimerColumn.Name = "btnSupprimerColumn";
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(436, 417);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(122, 40);
            this.btnRetour.TabIndex = 5;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // ListCommandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 552);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.pbLogochef);
            this.Controls.Add(this.dgvCommandes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListCommandes";
            this.Text = "ListCommandes";
            this.Load += new System.EventHandler(this.ListCommandes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogochef)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCommandes;
        private System.Windows.Forms.PictureBox pbLogochef;
        private System.Windows.Forms.DataGridViewButtonColumn btnSupprimerColumn;
        private System.Windows.Forms.Button btnRetour;
    }
}