using Microsoft.VisualStudio.TestTools.UnitTesting;
using schipv3.Classes;
using System.Collections.Generic;

namespace UnitTesten
{
    [TestClass]
    public class SchipInfo
    {
        private Schip schip = new Schip();

        [TestMethod]
        public void GoedAantalRijen()
        {
            Schip newschip = new Schip(5, 5);
            newschip.MaakRijen();
            Assert.AreEqual(5, newschip.Rijen.Count);
            Assert.AreEqual(5, newschip.MaxBreedteRijen);
        }

        [TestMethod]
        public void FoutAantalRijen()
        {
            Schip newschip = new Schip(4, 4);
            Assert.AreNotSame(5, newschip.Rijen);
            Assert.AreNotSame(5, newschip.MaxBreedteRijen);
        }

        [TestMethod]
        public void KrijgMaximaalGewichtSchipGoed()
        {
            Schip newschip = new Schip(5, 5);
            Assert.AreEqual(3750000, newschip.MaxGewichtSchip);
        }

        [TestMethod]
        public void KrijgMaximaalGewichtSchipFout()
        {
            Schip newschip = new Schip(5, 5);
            Assert.AreNotSame(3750001, newschip.MaxGewichtSchip);
        }

        [TestMethod]
        public void overMaximaalGewicht()
        {
            Schip newschip = new Schip(5,5);
            newschip.HuidigGewichtSchip = 1875000;
            Assert.IsTrue(newschip.OverMinimaalGewicht());
        }


    }
}