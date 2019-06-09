using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schipv3.Classes
{
  public  class Container
    {
        public string Soort;
        public int[,,] Plek;
        public int[] PlekNormaleArray;
        public Container(string soort, int gewicht)
        {
            Soort = soort;
            Gewicht = gewicht;
            // kijken of het gewicht goed is volgens de regels
            if (gewicht < 4000 || gewicht > 30000)
            {
                throw new System.ArgumentException("Pas het gewicht aan!");
            }

        }

        public int Breedte { get; set; }

        public int Rijnummer { get; set; }

        public int Gewicht { get; set; }

        public int Hoogte { get; set; }

        public override string ToString()
        {
            string PlaatsvanContainer = "";
            if (Plek != null)
            {

                string lengte = String.Join(",", Plek.GetLength(0));
                string breedte = String.Join(",", Plek.GetLength(1));
                string hoogte = String.Join(",", Plek.GetLength(2));
                PlaatsvanContainer = "hoogte:  " + hoogte + "  Breedte  " + breedte + " Rijnummer  " + lengte;

            }

            return Soort + " " + Gewicht + "  " + PlaatsvanContainer;
        }
    }
}
