using System;
using System.Linq;
using AxiLogic.Classes;
using AxiLogic.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.ContainerTests
{
    [TestClass]
    public class ShipmentContainerTests
    {

        [TestMethod]
        public void AddShipment()
        {
            //arrange
            var container = new ShipmentContainer();
            var shipment = new Shipment(1);
            //act
            container.AddShipment(shipment);
            //assert
            Assert.IsTrue(container.GetShipments().Contains(shipment));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateEmployee()
        {
            //arrange
            var container = new ShipmentContainer();
            var shipment = new Shipment(1);
            container.AddShipment(shipment);
            //act
            container.AddShipment(shipment);
            //assert
            Assert.IsTrue(container.GetShipments().Count==1);
        }
        
        [TestMethod]
        public void RemoveShipment()
        {
            //arrange
            var container = new ShipmentContainer();
            var shipment = new Shipment(1);
            container.AddShipment(shipment);
            //act
            container.RemoveShipment(shipment);
            //assert
            Assert.IsFalse(container.GetShipments().Contains(shipment));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonContainedEmployee()
        {
            //arrange
            var container = new ShipmentContainer();
            var shipment = new Shipment(1);
            //act
            container.RemoveShipment(shipment);
            //assert
            Assert.IsTrue(container.GetShipments().Count==0);
        }
        
        [TestMethod]
        public void ClearShipmentsTest()
        {
            //arrange
            var container = new ShipmentContainer();
            var shipment1 = new Shipment(1);
            var shipment2 = new Shipment(2);
            var shipment3 = new Shipment(3);
            container.AddShipment(shipment1);
            container.AddShipment(shipment2);
            container.AddShipment(shipment3);
            //act
            container.ClearShipments();
            //assert
            Assert.IsFalse(container.GetShipments().Contains(shipment1));
            Assert.IsFalse(container.GetShipments().Contains(shipment2));
            Assert.IsFalse(container.GetShipments().Contains(shipment3));
        }
    }
}