using System.Collections.Generic;

namespace schipv3.Classes
{
    public class Rij
    {
        public int breedte;

        public int RijNummer;

        public List<Stapel> Stapel = new List<Stapel>();

        public Rij()
        { }

        public Rij(int Breedte, int rijnummer)
        {
            RijNummer = rijnummer;
            breedte = Breedte;
        }

        public override string ToString()
        {
            return /*Stapel*/   RijNummer.ToString();
        }
    }
}