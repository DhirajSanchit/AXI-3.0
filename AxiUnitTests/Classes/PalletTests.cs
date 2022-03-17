using System;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class PalletTests
    {
        [TestMethod]
        public void PlaceNewArticle()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            //act
            pallet.PlaceArticle(article1, 3);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(3, pallet.Amount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlaceWrongArticle()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            var article2 = new Article("testName2",10.33);
            pallet.PlaceArticle(article1, 3);
            //act
            pallet.PlaceArticle(article2, 5);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(3, pallet.Amount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceNegativeAmount()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            pallet.PlaceArticle(article1, 2);
            //act
            pallet.PlaceArticle(article1, -3);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(2, pallet.Amount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceZeroAmount()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            pallet.PlaceArticle(article1, 2);
            //act
            pallet.PlaceArticle(article1, 0);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(2, pallet.Amount);
        }
        
        [TestMethod]
        public void RemoveValidAmount()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            pallet.PlaceArticle(article1, 3);
            //act
            pallet.RemoveArticle(article1,3);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(0, pallet.Amount);
        } 
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeAmount()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            pallet.PlaceArticle(article1, 4);
            //act
            pallet.RemoveArticle(article1,-3);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(4, pallet.Amount);
        } 
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveZeroAmount()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            pallet.PlaceArticle(article1, 4);
            //act
            pallet.RemoveArticle(article1,0);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(4, pallet.Amount);
        } 
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTooMuch()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            pallet.PlaceArticle(article1, 3);
            //act
            pallet.RemoveArticle(article1,4);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(3, pallet.Amount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveWrongArticle()
        {
            //arrange
            var pallet = new Pallet();
            var article1 = new Article("testName",10.50);
            var article2 = new Article("testName2",10.33);
            pallet.PlaceArticle(article1, 3);
            //act
            pallet.RemoveArticle(article2,2);
            //assert
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(3, pallet.Amount);
        }

        [TestMethod]
        public void CreatePallet()
        {
            //arrange
            //act
            var pallet = new Pallet();
            //assert
            Assert.IsNotNull(pallet);
        }
    }
}