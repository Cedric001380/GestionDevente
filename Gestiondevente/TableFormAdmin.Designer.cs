namespace Gestiondevente
{
    partial class TableFormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableFormAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumtable = new System.Windows.Forms.TextBox();
            this.txtEmplacement = new System.Windows.Forms.TextBox();
            this.txtStatut = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.btnModifierColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSupprimerColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pbImageBanc = new System.Windows.Forms.PictureBox();
            this.btnChoisirImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnRetour = new System.Windows.Forms.Button();
            this.btnMiseAjour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBanc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion Intuitive des Tables";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de la table :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Emplacement";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(127, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Statut de la table :";
            // 
            // txtNumtable
            // 
            this.txtNumtable.Location = new System.Drawing.Point(299, 176);
            this.txtNumtable.Name = "txtNumtable";
            this.txtNumtable.Size = new System.Drawing.Size(265, 20);
            this.txtNumtable.TabIndex = 4;
            this.txtNumtable.TextChanged += new System.EventHandler(this.txtNumtable_TextChanged);
            // 
            // txtEmplacement
            // 
            this.txtEmplacement.Location = new System.Drawing.Point(299, 219);
            this.txtEmplacement.Name = "txtEmplacement";
            this.txtEmplacement.Size = new System.Drawing.Size(265, 20);
            this.txtEmplacement.TabIndex = 5;
            this.txtEmplacement.TextChanged += new System.EventHandler(this.txtEmplacement_TextChanged);
            // 
            // txtStatut
            // 
            this.txtStatut.Location = new System.Drawing.Point(299, 265);
            this.txtStatut.Name = "txtStatut";
            this.txtStatut.Size = new System.Drawing.Size(265, 20);
            this.txtStatut.TabIndex = 6;
            this.txtStatut.TextChanged += new System.EventHandler(this.txtStatut_TextChanged);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.Transparent;
            this.btnAjouter.Location = new System.Drawing.Point(165, 522);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(84, 34);
            this.btnAjouter.TabIndex = 7;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Blue;
            this.btnRechercher.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Image = ((System.Drawing.Image)(resources.GetObject("btnRechercher.Image")));
            this.btnRechercher.Location = new System.Drawing.Point(919, 159);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(86, 27);
            this.btnRechercher.TabIndex = 10;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRechercher
            // 
            this.txtRechercher.Location = new System.Drawing.Point(642, 169);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(233, 20);
            this.txtRechercher.TabIndex = 11;
            this.txtRechercher.TextChanged += new System.EventHandler(this.txtRechercher_TextChanged);
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnModifierColumn,
            this.btnSupprimerColumn});
            this.dgvTable.Location = new System.Drawing.Point(642, 203);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(384, 111);
            this.dgvTable.TabIndex = 12;
            this.dgvTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
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
            // pbImageBanc
            // 
            this.pbImageBanc.Location = new System.Drawing.Point(332, 332);
            this.pbImageBanc.Name = "pbImageBanc";
            this.pbImageBanc.Size = new System.Drawing.Size(241, 148);
            this.pbImageBanc.TabIndex = 13;
            this.pbImageBanc.TabStop = false;
            this.pbImageBanc.Click += new System.EventHandler(this.pbImageBanc_Click);
            // 
            // btnChoisirImage
            // 
            this.btnChoisirImage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoisirImage.ForeColor = System.Drawing.Color.White;
            this.btnChoisirImage.Image = ((System.Drawing.Image)(resources.GetObject("btnChoisirImage.Image")));
            this.btnChoisirImage.Location = new System.Drawing.Point(626, 399);
            this.btnChoisirImage.Name = "btnChoisirImage";
            this.btnChoisirImage.Size = new System.Drawing.Size(127, 34);
            this.btnChoisirImage.TabIndex = 14;
            this.btnChoisirImage.Text = "Choisir\r\n";
            this.btnChoisirImage.UseVisualStyleBackColor = true;
            this.btnChoisirImage.Click += new System.EventHandler(this.btnChoisirImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 321);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Image :";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(108, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(141, 141);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 16;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.ForeColor = System.Drawing.Color.Transparent;
            this.btnRetour.Location = new System.Drawing.Point(766, 518);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(94, 34);
            this.btnRetour.TabIndex = 17;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // btnMiseAjour
            // 
            this.btnMiseAjour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnMiseAjour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiseAjour.ForeColor = System.Drawing.Color.White;
            this.btnMiseAjour.Location = new System.Drawing.Point(513, 518);
            this.btnMiseAjour.Name = "btnMiseAjour";
            this.btnMiseAjour.Size = new System.Drawing.Size(107, 34);
            this.btnMiseAjour.TabIndex = 26;
            this.btnMiseAjour.Text = "Mise à jour";
            this.btnMiseAjour.UseVisualStyleBackColor = false;
            this.btnMiseAjour.Click += new System.EventHandler(this.btnMiseAjour_Click);
            // 
            // TableFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 577);
            this.Controls.Add(this.btnMiseAjour);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChoisirImage);
            this.Controls.Add(this.pbImageBanc);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.txtRechercher);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtStatut);
            this.Controls.Add(this.txtEmplacement);
            this.Controls.Add(this.txtNumtable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableFormAdmin";
            this.Text = "TableFormAdmin";
            this.Load += new System.EventHandler(this.TableFormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBanc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumtable;
        private System.Windows.Forms.TextBox txtEmplacement;
        private System.Windows.Forms.TextBox txtStatut;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.PictureBox pbImageBanc;
        private System.Windows.Forms.Button btnChoisirImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewButtonColumn btnModifierColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnSupprimerColumn;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Button btnMiseAjour;
    }
}