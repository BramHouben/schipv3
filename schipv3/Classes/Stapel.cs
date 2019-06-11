using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schipv3.Classes
{
  public  class Stapel
    {
        public int[] Plaats;
        public List<Container> Containers = new List<Container>();

        public int HuidigGewichtStapel;
        public int BreedtePlek;
        public int MaxGewichtStapel = 150000;
        public int hoogte = 0;

        public Stapel(int breedte, int rijnummer)
        {
            BreedtePlek = breedte;
            Plaats = new int[] { breedte, rijnummer };
            HuidigGewichtStapel = 0;
            List<Container> Containers = new List<Container>();
        }

        internal void ToevoegenContainer(Container container, int Rijnummer)
        {
            container.Hoogte = Containers.Count;
            container.PlekNormaleArray = new int[] {Rijnummer, container.Hoogte, BreedtePlek };
            container.Plek = new int[Rijnummer, BreedtePlek, container.Hoogte];
            HuidigGewichtStapel += container.Gewicht;
            Containers.Add(container);
        }

        internal bool CheckGewicht(int gewicht)
        {
            HuidigGewichtStapel += gewicht;
            if (HuidigGewichtStapel <= MaxGewichtStapel)
            {
                HuidigGewichtStapel -= gewicht;
                return true;
            }
            else
            {
                HuidigGewichtStapel -= gewicht;
                return false;
            }
        }

        internal bool MaxGewichtEenContainer(int gewicht2)
        {
            int gewicht = Containers.Skip(1).Sum(x => x.Gewicht);
            gewicht += gewicht2;
            if (gewicht <= 120000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string plaatsString = String.Join(" ", Plaats.Cast<int>());
            return "Gewicht:    " + HuidigGewichtStapel + "   OP de plek   " + plaatsString;
        }


    }
}
