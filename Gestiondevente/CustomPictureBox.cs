using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Gestiondevente
{
    public class CustomPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Appeler la méthode de base pour dessiner le contenu par défaut
            base.OnPaint(pe);

            // Activer l'anticrénelage pour des bords lisses
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (this.Image != null)
            {
                // Créer un chemin graphique en forme de cercle
                GraphicsPath path = new GraphicsPath();
                int diameter = Math.Min(this.Width, this.Height);
                path.AddEllipse(0, 0, diameter - 1, diameter - 1);

                // Appliquer le chemin comme une région de découpe (mask)
                this.Region = new Region(path);

                // Dessiner l'image dans la zone de découpe
                pe.Graphics.DrawImage(this.Image, 0, 0, this.Width, this.Height);
            }
        }
    }
}