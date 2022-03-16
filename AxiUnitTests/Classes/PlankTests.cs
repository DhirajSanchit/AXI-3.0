using System;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class PlankTests
    {
        [TestMethod]
        public void TestRemovePallet()
        {
            //arrange
            var plank = new Plank();
            var pallet = new Pallet();
            plank.CreatePallet(pallet);
            //act
            plank.RemovePallet(pallet);
            //assert
            Assert.IsTrue(plank.GetPallets().Count == 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNotContainedPallet()
        {
            //arrange
            var plank = new Plank();
            var pallet = new Pallet();
            var pallet2 = new Pallet();
            plank.CreatePallet(pallet);
            //act
            plank.RemovePallet(pallet2);
            //assert
            Assert.IsTrue(plank.GetPallets().Count == 1);
        }
    }
}