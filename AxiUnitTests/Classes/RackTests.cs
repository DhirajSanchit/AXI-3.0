using System;
using System.Linq;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class RackTests
    {
        [TestMethod]
        public void TestRemovePlank()
        {
            //arrange
            var rack = new Rack(134);
            var plank = new Plank(134);
            rack.AddPlank(plank);
            //act
            rack.RemovePlank(plank);
            //assert
            Assert.IsTrue(rack.Planks.Count == 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNotContainedPlank()
        {
            //arrange
            var rack = new Rack(134);
            var plank = new Plank(134);
            var plank2 = new Plank(134);
            rack.AddPlank(plank);
            //act
            rack.RemovePlank(plank2);
            //assert
            Assert.IsTrue(rack.Planks.Count == 1);
        }
        
        [TestMethod]
        public void TestAddPlank()
        {
            //arrange
            var rack = new Rack(134);
            var plank = new Plank(134);
            //act
            rack.AddPlank(plank);
            //assert
            Assert.IsTrue(rack.Planks.Contains(plank),"Plank was not added to the list");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddDuplicatePlank()
        {
            //arrange
            var rack = new Rack(134);
            var plank = new Plank(134);
            rack.AddPlank(plank);
            //act
            rack.AddPlank(plank);
            //assert
            Assert.IsTrue(rack.Planks.Count == 1);
        }
        
        [TestMethod]
        public void CreateRack()
        {
            //arrange
            //act
            var rack = new Rack(134);
            //assert
            Assert.IsNotNull(rack);
        }
    }
}