namespace Gestiondevente
{
    partial class ListPaiment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPaiment));
            this.dataGridViewPaiment = new System.Windows.Forms.DataGridView();
            this.btnAccepterColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRefuserColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRetour = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaiment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPaiment
            // 
            this.dataGridViewPaiment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaiment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnAccepterColumn,
            this.btnRefuserColumn});
            this.dataGridViewPaiment.Location = new System.Drawing.Point(260, 94);
            this.dataGridViewPaiment.Name = "dataGridViewPaiment";
            this.dataGridViewPaiment.Size = new System.Drawing.Size(683, 217);
            this.dataGridViewPaiment.TabIndex = 0;
            this.dataGridViewPaiment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPaiment_CellContentClick);
            // 
            // btnAccepterColumn
            // 
            this.btnAccepterColumn.HeaderText = "Accepter";
            this.btnAccepterColumn.Name = "btnAccepterColumn";
            // 
            // btnRefuserColumn
            // 
            this.btnRefuserColumn.HeaderText = "Refuser";
            this.btnRefuserColumn.Name = "btnRefuserColumn";
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(491, 352);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(122, 40);
            this.btnRetour.TabIndex = 4;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(41, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(147, 153);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 14;
            this.pictureBoxLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(427, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Liste des paiment en cours";
            // 
            // ListPaiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.dataGridViewPaiment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListPaiment";
            this.Text = "ListPaiment";
            this.Load += new System.EventHandler(this.ListPaiment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaiment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPaiment;
        private System.Windows.Forms.DataGridViewButtonColumn btnAccepterColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnRefuserColumn;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label label1;
    }
}