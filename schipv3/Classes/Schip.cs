using System;
using System.Collections.Generic;
using System.Linq;

namespace schipv3.Classes
{
    public class Schip
    {
        //  SchipInfo
        public int HuidigGewichtSchip;

        public int MaxGewichtSchip;
        public double helft2;

        public Schip()
        {
        }

        public Schip(int lengte, int breedte)
        {
            double helft = (double) breedte / 2;
            helft2 = helft ;
            if ((helft2 % 1) > 0)
            {
                helft2 += 0.5;
            }
            MaximaalAantalRijen = lengte;
            MaxBreedteRijen = breedte;
            //  Dit is wat maximaal op het schip mag
            MaxGewichtSchip = breedte * lengte * 150000;
        }

        // lijsten voor containers
        public List<Container> Normaal = new List<Container>();

        public List<Container> Gekoeld = new List<Container>();
        public List<Container> Waardevol = new List<Container>();
        private List<Container> GesoorteerdNormaal;
        private List<Container> GesoorteerdGekoeld;
        private List<Container> GesoorteerdWaardevol;
        public List<Rij> Rijen = new List<Rij>();

        private Rij rij = new Rij();

        // rij info
        public int MaxBreedteRijen;

        public int MaximaalAantalRijen;

        // kant info
        public double GewichtLinks = 1;

        public double GewichtRechts = 1;
        public int GewichtMidden = 1;

   

        internal bool OverMinimaalGewicht()
        {
            int minimaalGewicht = MaxGewichtSchip / 2;
            if (HuidigGewichtSchip < minimaalGewicht)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void MaakRijen()
        {
            int plekstapel = 0;
            int Plekrij = 0;
            for (int i = 0; i < MaximaalAantalRijen; i++)
            {
                Rij rij = new Rij(MaxBreedteRijen, Plekrij);
                rij.RijNummer = Plekrij;
                rij.breedte = MaxBreedteRijen;
                for (int j = 0; j < MaxBreedteRijen; j++)
                {
                    rij.Stapel.Add(new Stapel(plekstapel, Plekrij));
                    plekstapel++;
                }
                plekstapel = 0;
                Rijen.Add(rij);
                Plekrij++;
            }
        }

        internal void SoorterenLijstenOpGewicht()
        {
            GesoorteerdNormaal = Normaal.OrderBy(x => x.Gewicht).ToList();
            GesoorteerdGekoeld = Gekoeld.OrderBy(x => x.Gewicht).ToList();
            GesoorteerdWaardevol = Waardevol.OrderBy(x => x.Gewicht).ToList();
        }

        internal void ToevoegenContainer(Container container)
        {
            switch (container.Soort)
            {
                case "Normaal":
                    Normaal.Add(container);
                    break;

                case "Gekoeld":
                    Gekoeld.Add(container);
                    break;

                case "Waardevol":
                    Waardevol.Add(container);
                    break;
            }
        }

        internal void PlaatsenGekoeld()
        {
            foreach (Container container in GesoorteerdGekoeld.ToList())
            {
                CheckGewicht(container);
            }
        }
        internal void PlaatsenNormaal()
        {
            foreach (Container container in GesoorteerdNormaal.ToList())
            {
                CheckGewichtNormaal(container);
            }
        }



        private void CheckGewicht(Container container)
        {
            foreach (Rij rij in Rijen.Where(x => x.RijNummer == 0))
            {
                if (HuidigGewichtSchip < MaxGewichtSchip)
                {
                    if (GesoorteerdGekoeld.Count > 0)
                    {
                        if (CheckVerschil() == true)
                        {
                            foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek < helft2))
                            {
                                int breedte = stapel.BreedtePlek;
                                if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                                {
                                    container.Hoogte = stapel.Containers.Count;
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    stapel.Containers.Add(container);
                                    GewichtLinks += container.Gewicht;
                                    HuidigGewichtSchip += container.Gewicht;
                                    stapel.HuidigGewichtStapel += container.Gewicht;
                                    GesoorteerdGekoeld.RemoveAt(0);
                                    break;
                                }
                             
                            }
                        }
                        else
                        {
                         
                            foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek >= helft2))
                            {
                                int breedte = stapel.BreedtePlek;
                                if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                                {
                                    container.Hoogte = stapel.Containers.Count;
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    stapel.Containers.Add(container);
                                    GewichtRechts += container.Gewicht;
                                    HuidigGewichtSchip += container.Gewicht;
                                    stapel.HuidigGewichtStapel += container.Gewicht;
                                    GesoorteerdGekoeld.RemoveAt(0);
                                  
                                    break;
                                   
                                }
                             
                            }
                        }
                    }
                }
         
            }

        }
        private void CheckGewichtNormaal(Container container)
        {
            bool ingedeeld = false ;
            foreach (Rij rij in Rijen)
            {
                if (HuidigGewichtSchip < MaxGewichtSchip)
                {
                    if (GesoorteerdNormaal.Count > 0)
                    {
                        if (CheckVerschil() == true)
                        {
                            foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek < helft2))
                            {
                             
                                if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                                {
                                    int breedte = stapel.BreedtePlek;
                                    container.Hoogte = stapel.Containers.Count;
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    stapel.Containers.Add(container);
                                    GewichtLinks += container.Gewicht;
                                    HuidigGewichtSchip += container.Gewicht;
                                    stapel.HuidigGewichtStapel += container.Gewicht;
                                    GesoorteerdNormaal.RemoveAt(0);
                                    ingedeeld = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                                
                            }
                            if (ingedeeld ==true)
                            {
                                break;
                            }
                            else
                            {
                                if (rij.RijNummer == MaximaalAantalRijen-1)
                                {//voor de laatse rij fix
                                    GewichtLinks += container.Gewicht;
                                }
                                continue;
                            
                            }
                        }
                        else
                        {

                            foreach (Stapel stapel2 in rij.Stapel.Where(x => x.BreedtePlek >= helft2))
                            {
                     
                                if (stapel2.MaxGewichtEenContainer(container.Gewicht) == true && stapel2.CheckGewicht(container.Gewicht) == true)
                                {
                                    int breedte = stapel2.BreedtePlek;
                                    container.Hoogte = stapel2.Containers.Count;
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    stapel2.Containers.Add(container);
                                    GewichtRechts += container.Gewicht;
                                    HuidigGewichtSchip += container.Gewicht;
                                    stapel2.HuidigGewichtStapel += container.Gewicht;
                                    GesoorteerdNormaal.RemoveAt(0);
                                    ingedeeld = true;

                                    break;

                                }
                                else
                                {
                                    continue;
                                }
                               
                            }
                            if (ingedeeld == true)
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        //break;
                    }
                }
                else
                {
                    GesoorteerdNormaal.Clear();
                }
            }
        }

        private bool CheckVerschil()
        {
            double Verschil = GewichtLinks / GewichtRechts;
            double UItslag = Verschil * 100;
            if (UItslag > 120)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}