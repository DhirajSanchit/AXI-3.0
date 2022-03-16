using System;
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
            var rack = new Rack();
            var plank = new Plank();
            rack.CreatePlank(plank);
            //act
            rack.RemovePlank(plank);
            //assert
            Assert.IsTrue(rack.GetPlanks().Count == 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNotContainedPlank()
        {
            //arrange
            var rack = new Rack();
            var plank = new Plank();
            var plank2 = new Plank();
            rack.CreatePlank(plank);
            //act
            rack.RemovePlank(plank2);
            //assert
            Assert.IsTrue(rack.GetPlanks().Count == 1);
        }
    }
}