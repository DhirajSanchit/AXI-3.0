using System;
using AxiInterfaces.DTOs;
using AxiLogic.Classes;
using AxiLogic.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.ContainerTests
{
    [TestClass]
    public class RowContainerTest
    {
        [TestMethod]
        public void CreateRowTest()
        {
            //arrange
            var container = new RowContainer();
            var row = new Row("test");
            //act
            container.AddRow(row);
            //assert
            Assert.IsTrue(container.Rows.Contains(row));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateDuplicateRow()
        {
            //arrange
            var container = new RowContainer();
            var row = new Row("test");
            container.AddRow(row);
            //act
            container.AddRow(row);
            //assert
            Assert.IsTrue(container.Rows.Count==1);
        }

        [TestMethod]
        public void RemoveRow()
        {
            //arrange
            var container = new RowContainer();
            var row = new Row("test");
            container.AddRow(row);
            //act
            container.RemoveRow(row);
            //assert
            Assert.IsFalse(container.Rows.Contains(row));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonContainedRow()
        {
            //arrange
            var container = new RowContainer();
            var row = new Row("test");
            //act
            container.RemoveRow(row);
            //assert
            Assert.IsTrue(container.Rows.Count==0);
        }
    }
}