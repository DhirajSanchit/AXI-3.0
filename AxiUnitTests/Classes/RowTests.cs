using System;
using System.Linq;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void TestRemoveRack()
        {
            //arrange
            var row = new Row();
            var rack = new Rack();
            row.AddRack(rack);
            //act
            row.RemoveRack(rack);
            //assert
            Assert.IsTrue(row.GetRacks().Count == 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNotContainedRack()
        {
            //arrange
            var row = new Row();
            var rack = new Rack();
            var rack2 = new Rack();
            row.AddRack(rack);
            //act
            row.RemoveRack(rack2);
            //assert
            Assert.IsTrue(row.GetRacks().Count == 1, "Remove function removed object even though it was not contained");
        }
        
        [TestMethod]
        public void TestAddRack()
        {
            //arrange
            var row = new Row();
            var rack = new Rack();
            //act
            row.AddRack(rack);
            //assert
            Assert.IsTrue(row.GetRacks().Contains(rack),"Rack was not added");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddDuplicateRack()
        {
            //arrange
            var row = new Row();
            var rack = new Rack();
            row.AddRack(rack);
            //act
            row.AddRack(rack);
            //assert
            Assert.IsTrue(row.GetRacks().Count == 1, "Adding duplicate was allowed");
        }
        
        [TestMethod]
        public void TestCreateRow()
        {
            //arrange
            var name = "row3";
            //act
            var row = new Row(name);
            //assert
            Assert.IsNotNull(row);
            Assert.AreEqual(name, row.Name);
        }

        [TestMethod]
        public void TestSetName()
        {
            //arrange
            var row = new Row();
            var name = "someName";
            //act
            row.SetName(name);
            //assert
            Assert.AreEqual(name, row.Name);
        }
    }
}