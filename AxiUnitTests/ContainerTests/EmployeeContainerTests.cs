using System;
using System.Linq;
using AxiLogic.Classes;
using AxiLogic.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AxiUnitTests.ContainerTests
{
    [TestClass]
    public class EmployeeContainerTest
    {
        //URGENT DAL NIET GEIMPLEMENTEERD!!!
        [TestMethod]
        public void AddEmployeeTest()
        {
            //arrange
            var container = new EmployeeContainer();
            var employee = new Employee("John Doe","john@test.com");
            //act
            container.AddEmployee(employee);
            //assert
            Assert.IsTrue(container.GetEmployees().Contains(employee));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateEmployee()
        {
            //arrange
            var container = new EmployeeContainer();
            var employee = new Employee("John Doe", "john@test.com");
            container.AddEmployee(employee);
            //act
            container.AddEmployee(employee);
            //assert
            Assert.IsTrue(container.GetEmployees().Count==1);
        }

        [TestMethod]
        public void RemoveEmployeeTest()
        {
            //arrange
            var container = new EmployeeContainer();
            var employee = new Employee("John Doe", "John@test.com");
            container.AddEmployee(employee);
            //act
            container.RemoveEmployee(employee);
            //assert
            Assert.IsFalse(container.GetEmployees().Contains(employee));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonContainedEmployee()
        {
            //arrange
            var container = new EmployeeContainer();
            var employee = new Employee("John Doe", "John@gmail.com");
            //act
            container.RemoveEmployee(employee);
            //assert
            Assert.IsTrue(container.GetEmployees().Count==0);
        }
    }
}