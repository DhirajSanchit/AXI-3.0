using System;
using AxiDAL.DAL;
using AxiDAL.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests
{
    [TestClass]
    public class shipmentDalTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            var dal = new ShipmentDAL();
            var test = dal.GetAll();
            Assert.AreEqual(test, true);
        }

        [TestMethod]
        public void AddShipmentTest()
        {
            var dal = new ShipmentDAL();
            var test = dal.AddShipment(new ShipmentDto()
            {
                Name = "TestName",
                Date = DateTime.Now,
                InvoiceId = 1,
                Processed = true
            });
            Assert.AreEqual(test, true);
        }
        
        [TestMethod]
        public void UpdateShipmentTest()
        {
            var dal = new ShipmentDAL();
            var test = dal.UpdateShipment(new ShipmentDto()
            {
                Name = "TestName",
                Date = DateTime.Now,
                InvoiceId = 1,
                Processed = true,
                Id = 1
            });
            Assert.AreEqual(test, true);
        }
    }
}