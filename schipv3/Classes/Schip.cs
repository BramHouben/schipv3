using System.Collections.Generic;
using System.Linq;

namespace schipv3.Classes
{
    public class Schip
    {
        //  SchipInfo
        private int HuidigGewichtSchip;

        private int MaxGewichtSchip;
        private double helft2;
        private double RijMidden;

        public Schip()
        {
        }

        public Schip(int lengte, int breedte)
        {
            double helft = (double)breedte / 2;
            helft2 = helft;
            if (breedte == 1)
            {
                helft2 = 1;
            }
            else if ((helft2 % 1) > 0)
            {
                helft2 -= 0.5;
                RijMidden = helft2;
            }

            MaximaalAantalRijen = lengte;
            MaxBreedteRijen = breedte;
            //  Dit is wat maximaal op het schip mag
            MaxGewichtSchip = breedte * lengte * 150000;
        }

        // lijsten voor containers
        private List<Container> Normaal = new List<Container>();

        private List<Container> Gekoeld = new List<Container>();
        private List<Container> Waardevol = new List<Container>();
        private List<Container> GesoorteerdNormaal;
        private List<Container> GesoorteerdGekoeld;
        private List<Container> GesoorteerdWaardevol;
        public List<Rij> Rijen = new List<Rij>();

        private Rij rij = new Rij();

        // rij info
        public int MaxBreedteRijen;

        private int MaximaalAantalRijen;

        // kant info
        private double GewichtLinks = 1;

        private double GewichtRechts = 1;

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
            GesoorteerdNormaal = Normaal.OrderByDescending(x => x.Gewicht).ToList();
            GesoorteerdGekoeld = Gekoeld.OrderByDescending(x => x.Gewicht).ToList();
            GesoorteerdWaardevol = Waardevol.OrderByDescending(x => x.Gewicht).ToList();
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

        internal void PlaatsenWaardevol()
        {
            foreach (Container container in GesoorteerdWaardevol.ToList())
            {
                CheckGewichtWaardevol(container);
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
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, breedte };
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    stapel.Containers.Add(container);
                                    if (helft2 == 1)
                                    {
                                        GewichtLinks = 1;
                                    }
                                    else
                                    {
                                        GewichtLinks += container.Gewicht;
                                    }

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
                                    if (stapel.BreedtePlek == RijMidden)
                                    {
                                        continue;
                                    }
                                    container.Hoogte = stapel.Containers.Count;
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, breedte };
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
            bool ingedeeld = false;
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
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, breedte };
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    stapel.Containers.Add(container);
                                    // fix 1 rij//////////////////////////////
                                    if (helft2 == 1)
                                    {
                                        GewichtLinks = 1;
                                    }
                                    else
                                    {
                                        GewichtLinks += container.Gewicht;
                                    }
                                    ////////////////////////////////////////
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
                            if (ingedeeld == true)
                            {
                                break;
                            }
                            else
                            {
                                if (rij.RijNummer == MaximaalAantalRijen - 1)
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
                                    if (stapel2.BreedtePlek == RijMidden)
                                    {
                                        continue;
                                    }
                                    int breedte = stapel2.BreedtePlek;
                                    container.Hoogte = stapel2.Containers.Count;
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, breedte };
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

        private void CheckGewichtWaardevol(Container container)
        {
            bool ingedeeld = false;
            foreach (Rij rij in Rijen)
            {
                if (HuidigGewichtSchip < MaxGewichtSchip)
                {
                    if (GesoorteerdWaardevol.Count > 0)
                    {
                        if (CheckVerschil() == true)
                        {
                            foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek < helft2))
                            {
                                if (stapel.Containers.Count >= 1)
                                {
                                    Container laatstecontainer = stapel.Containers.Last();
                                    if (laatstecontainer.Soort == "Waardevol")
                                    {
                                        continue;
                                    }
                                }


                                if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                                {
                                    int breedte = stapel.BreedtePlek;
                                    container.Hoogte = stapel.Containers.Count;
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, breedte };
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    if (KijkenVoorPlek(container, stapel, rij, breedte) == true)
                                    {
                                        stapel.Containers.Add(container);
                                        GewichtLinks += container.Gewicht;
                                        HuidigGewichtSchip += container.Gewicht;
                                        stapel.HuidigGewichtStapel += container.Gewicht;
                                        GesoorteerdWaardevol.RemoveAt(0);
                                        ingedeeld = true;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
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
                                if (rij.RijNummer == MaximaalAantalRijen - 1)
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
                                if (stapel2.Containers.Count >= 1)
                                {
                                    Container laatstecontainer = stapel2.Containers.Last();
                                    if (laatstecontainer.Soort == "Waardevol")
                                    {
                                        continue;
                                    }
                                }
                                if (stapel2.MaxGewichtEenContainer(container.Gewicht) == true && stapel2.CheckGewicht(container.Gewicht) == true)
                                {
                                    int breedte = stapel2.BreedtePlek;
                       
                                    container.Hoogte = stapel2.Containers.Count;
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, breedte };
                                    container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                    if (KijkenVoorPlek(container, stapel2, rij, breedte) == true)
                                    {
                                        container.Plek = new int[rij.RijNummer, breedte, container.Hoogte];
                                        stapel2.Containers.Add(container);
                                        GewichtRechts += container.Gewicht;
                                        HuidigGewichtSchip += container.Gewicht;
                                        stapel2.HuidigGewichtStapel += container.Gewicht;
                                        GesoorteerdWaardevol.RemoveAt(0);
                                        ingedeeld = true;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
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
                    GesoorteerdWaardevol.Clear();
                }
            }
        }

        private bool KijkenVoorPlek(Container container, Stapel stapel, Rij rij, int breedte)
        {
            bool Gelijk = false;
            int nieuwerij = rij.RijNummer;
            //int[,,] plekcontainer = container.Plek;
            if (rij.RijNummer !=0)
            {
                nieuwerij = rij.RijNummer - 1;
            }
            
            int hoogte = container.Hoogte;
            int[] test = new int[] { rij.RijNummer, breedte };
            /*container.Plek=*/
            int[,,] newcon = new int[nieuwerij, hoogte, breedte];
            int[] newconNormaalarray = new int[] { nieuwerij, hoogte, breedte };
            foreach (Rij item in Rijen.Where(x => x.RijNummer == nieuwerij))
            {
                foreach (Stapel stapelzoeken in item.Stapel.Where(x => x.BreedtePlek == breedte))
                {
           
      
                    //if (stapelzoeken.Plaats == test)
                    //{
                    foreach (Container ZoekenContainer in stapelzoeken.Containers.ToList())
                    {
                        if (ZoekenContainer.PlekNormaleArray== null)
                        {
                            return true;
                        }
                        Gelijk = Enumerable.SequenceEqual(ZoekenContainer.PlekNormaleArray, newconNormaalarray) ;
                        if (Gelijk == true)
                        {
                         
                                return false;
                 
                        }
                    }
                    //}
                    continue;
                }
            }
            return true;
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