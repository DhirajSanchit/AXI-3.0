using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void CreateEmployee()
        {
            //arrange
            var name = "Name";
            var email = "someemail@hotmail.com";
            //act
            var employee = new Employee(name,email);
            //assert
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(email, employee.Email);
        }
    }
}