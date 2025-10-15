namespace Gestiondevente
{
    partial class MainAffichageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAffichageForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelTables = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelPlats = new System.Windows.Forms.FlowLayoutPanel();
            this.grpPanier = new System.Windows.Forms.GroupBox();
            this.btnCommander = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lsbPanier = new System.Windows.Forms.ListBox();
            this.btnRetour = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpPanier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanelTables);
            this.panel1.Location = new System.Drawing.Point(283, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 338);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Les listes des tables pour notre restaurant";
            // 
            // flowLayoutPanelTables
            // 
            this.flowLayoutPanelTables.Location = new System.Drawing.Point(67, 45);
            this.flowLayoutPanelTables.Name = "flowLayoutPanelTables";
            this.flowLayoutPanelTables.Size = new System.Drawing.Size(781, 280);
            this.flowLayoutPanelTables.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.flowLayoutPanelPlats);
            this.panel2.Location = new System.Drawing.Point(98, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1289, 516);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(347, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Les listes des plats pour notre restaurant";
            // 
            // flowLayoutPanelPlats
            // 
            this.flowLayoutPanelPlats.Location = new System.Drawing.Point(35, 86);
            this.flowLayoutPanelPlats.Name = "flowLayoutPanelPlats";
            this.flowLayoutPanelPlats.Size = new System.Drawing.Size(1238, 401);
            this.flowLayoutPanelPlats.TabIndex = 0;
            this.flowLayoutPanelPlats.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelPlats_Paint);
            // 
            // grpPanier
            // 
            this.grpPanier.Controls.Add(this.btnCommander);
            this.grpPanier.Controls.Add(this.lblTotal);
            this.grpPanier.Controls.Add(this.lsbPanier);
            this.grpPanier.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpPanier.Location = new System.Drawing.Point(1241, 152);
            this.grpPanier.Name = "grpPanier";
            this.grpPanier.Size = new System.Drawing.Size(270, 340);
            this.grpPanier.TabIndex = 2;
            this.grpPanier.TabStop = false;
            this.grpPanier.Text = "Panier";
            this.grpPanier.Enter += new System.EventHandler(this.grpPanier_Enter);
            // 
            // btnCommander
            // 
            this.btnCommander.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCommander.ForeColor = System.Drawing.Color.White;
            this.btnCommander.Location = new System.Drawing.Point(85, 257);
            this.btnCommander.Name = "btnCommander";
            this.btnCommander.Size = new System.Drawing.Size(114, 38);
            this.btnCommander.TabIndex = 2;
            this.btnCommander.Text = "Commander";
            this.btnCommander.UseVisualStyleBackColor = false;
            this.btnCommander.Click += new System.EventHandler(this.btnCommander_Click_1);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(68, 217);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(62, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total : 0 Ar";
            // 
            // lsbPanier
            // 
            this.lsbPanier.FormattingEnabled = true;
            this.lsbPanier.Location = new System.Drawing.Point(22, 47);
            this.lsbPanier.Name = "lsbPanier";
            this.lsbPanier.Size = new System.Drawing.Size(228, 134);
            this.lsbPanier.TabIndex = 0;
            this.lsbPanier.SelectedIndexChanged += new System.EventHandler(this.lsbPanier_SelectedIndexChanged);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRetour.ForeColor = System.Drawing.Color.White;
            this.btnRetour.Location = new System.Drawing.Point(1393, 554);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(122, 40);
            this.btnRetour.TabIndex = 3;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(536, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(556, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passer une Commande et réserver une place à Sakafo Tracker";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(81, 28);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(127, 131);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 14;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // MainAffichageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 968);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.grpPanier);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainAffichageForm";
            this.Text = "MainAffichageForm";
            this.Load += new System.EventHandler(this.MainAffichageForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpPanier.ResumeLayout(false);
            this.grpPanier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTables;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPlats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpPanier;
        private System.Windows.Forms.Button btnCommander;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListBox lsbPanier;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}