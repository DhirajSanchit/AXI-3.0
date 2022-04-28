using AxiDAL.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests
{
    [TestClass]
    public class shipmentDalTest
    {
        [TestMethod]
        public void test()
        {
            var dal = new ShipmentDAL();
            var test = dal.GetAll();
            Assert.AreEqual(test, true);
        }
    }
}