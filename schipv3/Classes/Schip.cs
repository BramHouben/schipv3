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
        public double RijMidden;

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
        public List<Container> Normaal = new List<Container>();

        public List<Container> Gekoeld = new List<Container>();
        public List<Container> Waardevol = new List<Container>();
        public List<Container> GesoorteerdNormaal;
        public List<Container> GesoorteerdGekoeld;
        public List<Container> GesoorteerdWaardevol;
        public List<Rij> Rijen = new List<Rij>();

        // rij info
        public int MaxBreedteRijen;

        public int MaximaalAantalRijen;

        // kant info
        public double GewichtRechts = 1;

        public double GewichtLinks = 1;

        internal void PlaatsenMiddenGekoeld()
        {
            foreach (Container container in GesoorteerdGekoeld.ToList())
            {
                PlaatsGekoeldMidden(container);
            }
        }

        internal void PlaatsenMiddenNormaal()
        {
            foreach (Container container in GesoorteerdNormaal.ToList())
            {
                PlaatsNormaalMidden(container);
            }
        }

        private void PlaatsNormaalMidden(Container container)
        {
            bool ingedeeld = false;
            foreach (Rij rij in Rijen)
            {
                if (HuidigGewichtSchip < MaxGewichtSchip)
                {
                    if (GesoorteerdNormaal.Count > 0)
                    {
                        foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek == RijMidden))
                        {
                            if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                            {
                                stapel.ToevoegenContainer(container, rij.RijNummer);

                                GewichtToevoegenAanSchip(container);

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
                    }
                }
            }
        }

        private void PlaatsGekoeldMidden(Container container)
        {
            foreach (Rij rij in Rijen.Where(x => x.RijNummer == 0))
            {
                if (HuidigGewichtSchip < MaxGewichtSchip)
                {
                    if (GesoorteerdGekoeld.Count > 0)
                    {
                        foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek == RijMidden))
                        {
                            if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                            {
                                stapel.ToevoegenContainer(container, rij.RijNummer);
                                GewichtToevoegenAanSchip(container);

                                GesoorteerdGekoeld.RemoveAt(0);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool OverMinimaalGewicht()
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

        public void MaakRijen()
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

        private void ToevoegenGewichtRechts(Container container)
        {
            GewichtRechts += container.Gewicht;
        }

        private void ToevoegenGewichtLinks(Container container)
        {
            if (helft2 == 1)
            {
                GewichtLinks = 1;
            }
            else
            {
                GewichtLinks += container.Gewicht;
            }
        }

        public void GewichtToevoegenAanSchip(Container container)
        {
            HuidigGewichtSchip += container.Gewicht;
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
                                if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                                {
                                    stapel.ToevoegenContainer(container, rij.RijNummer);

                                    ToevoegenGewichtLinks(container);
                                    GewichtToevoegenAanSchip(container);
                                    GesoorteerdGekoeld.RemoveAt(0);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (Stapel stapel in rij.Stapel.Where(x => x.BreedtePlek >= helft2))
                            {
                                if (stapel.MaxGewichtEenContainer(container.Gewicht) == true && stapel.CheckGewicht(container.Gewicht) == true)
                                {
                                    if (RijMiddenFix(stapel) == true)

                                    {
                                        continue;
                                    }

                                    stapel.ToevoegenContainer(container, rij.RijNummer);

                                    ToevoegenGewichtRechts(container);
                                    GewichtToevoegenAanSchip(container);

                                    GesoorteerdGekoeld.RemoveAt(0);

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool RijMiddenFix(Stapel stapel)
        {
            if (stapel.BreedtePlek == RijMidden)
            {
                return true;
            }
            else { return false; }
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
                                    stapel.ToevoegenContainer(container, rij.RijNummer);

                                    ToevoegenGewichtLinks(container);

                                    GewichtToevoegenAanSchip(container);

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
                                    if (RijMiddenFix(stapel2) == true)

                                    {
                                        continue;
                                    }

                                    stapel2.ToevoegenContainer(container, rij.RijNummer);
                                    ToevoegenGewichtRechts(container);

                                    GewichtToevoegenAanSchip(container);

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
                                    container.Hoogte = stapel.Containers.Count;
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, stapel.BreedtePlek };
                                    container.Plek = new int[rij.RijNummer, stapel.BreedtePlek, container.Hoogte];
                                    if (KijkenVoorPlek(container, stapel, rij, stapel.BreedtePlek) == true)
                                    {
                                        stapel.ToevoegenContainer(container, rij.RijNummer);
                                        ToevoegenGewichtLinks(container);

                                        GewichtToevoegenAanSchip(container);

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
                                {
                                    //voor de laatse rij fix
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
                                    container.Hoogte = stapel2.Containers.Count;
                                    container.PlekNormaleArray = new int[] { rij.RijNummer, container.Hoogte, stapel2.BreedtePlek };
                                    container.Plek = new int[rij.RijNummer, stapel2.BreedtePlek, container.Hoogte];
                                    if (KijkenVoorPlek(container, stapel2, rij, stapel2.BreedtePlek) == true)
                                    {
                                        container.Plek = new int[rij.RijNummer, stapel2.BreedtePlek, container.Hoogte];
                                        stapel2.ToevoegenContainer(container, rij.RijNummer);
                                        ToevoegenGewichtRechts(container);
                                        GewichtToevoegenAanSchip(container);
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

            if (rij.RijNummer != 0)
            {
                nieuwerij = rij.RijNummer - 1;
            }

            int hoogte = container.Hoogte;
            int[] test = new int[] { rij.RijNummer, breedte };

            int[,,] newcon = new int[nieuwerij, hoogte, breedte];
            int[] newconNormaalarray = new int[] { nieuwerij, hoogte, breedte };
            foreach (Rij item in Rijen.Where(x => x.RijNummer == nieuwerij))
            {
                foreach (Stapel stapelzoeken in item.Stapel.Where(x => x.BreedtePlek == breedte))
                {
                    foreach (Container ZoekenContainer in stapelzoeken.Containers.ToList())
                    {
                        if (ZoekenContainer.PlekNormaleArray == null)
                        {
                            return true;
                        }
                        Gelijk = Enumerable.SequenceEqual(ZoekenContainer.PlekNormaleArray, newconNormaalarray);
                        if (Gelijk == true)
                        {
                            return false;
                        }
                    }

                    continue;
                }
            }
            return true;
        }

        public bool CheckVerschil()
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