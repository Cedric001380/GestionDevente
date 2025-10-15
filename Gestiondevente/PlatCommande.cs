using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiondevente
{
    public class PlatCommande
    {
        public int Id_plat { get; set; }
        public string Nom { get; set; }
        public float Prix { get; set; }
        public int Quantite { get; set; }

        public PlatCommande()
        {
            this.Quantite = 1;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} Ar", Nom, Prix);
        }
    }
}