using System;
using System.Linq;
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
            var plank = new Plank(134);
            var pallet = new Pallet(134);
            plank.AddPallet(pallet);
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
            var plank = new Plank(134);
            var pallet = new Pallet(134);
            var pallet2 = new Pallet(134);
            plank.AddPallet(pallet);
            //act
            plank.RemovePallet(pallet2);
            //assert
            Assert.IsTrue(plank.GetPallets().Count == 1);
        }
        
        [TestMethod]
        public void TestAddPallet()
        {
            //arrange
            var plank = new Plank(134);
            var pallet = new Pallet(134);
            //act
            plank.AddPallet(pallet);
            //assert
            Assert.IsTrue(plank.GetPallets().Contains(pallet),"Pallet was not added");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddDuplicatePallet()
        {
            //arrange
            var plank = new Plank(134);
            var pallet = new Pallet(134);
            plank.AddPallet(pallet);
            //act
            plank.AddPallet(pallet);
            //assert
            Assert.IsTrue(plank.GetPallets().Count == 1, "Adding duplicate was allowed");
        }
        
        [TestMethod]
        public void CreatePlank()
        {
            //arrange
            //act
            var plank = new Plank(134);
            //assert
            Assert.IsNotNull(plank);
        }
    }
}