using System;
using AxiDAL.DTOs;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class PalletTests
    {
        //[TestMethod]
        //public void PlaceNewArticle()
        //{
        //    //arrange
        //    var pallet = new Pallet(59);
        //    var article1 = new Article("testName",10.50);
        //    //act
        //    pallet.PlaceArticle(article1, 3);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(3, pallet.Amount);
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void PlaceWrongArticle()
        //{
        //    //arrange
        //    var pallet = new Pallet(501);
        //    var article1 = new Article("testName",10.50);
        //    var article2 = new Article("testName2",10.33);
        //    pallet.PlaceArticle(article1, 3);
        //    //act
        //    pallet.PlaceArticle(article2, 5);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(3, pallet.Amount);
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void PlaceNegativeAmount()
        //{
        //    //arrange
        //    var pallet = new Pallet(571);
        //    var article1 = new Article("testName",10.50);
        //    pallet.PlaceArticle(article1, 2);
        //    //act
        //    pallet.PlaceArticle(article1, -3);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(2, pallet.Amount);
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void PlaceZero()
        //{
        //    //arrange
        //    var pallet = new Pallet(461);
        //    var article1 = new Article("testName",10.50);
        //    pallet.PlaceArticle(article1, 2);
        //    //act
        //    pallet.PlaceArticle(article1, 0);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(2, pallet.Amount);
        //}
        
        //[TestMethod]
        //public void RemoveValidAmount()
        //{
        //    //arrange
        //    var pallet = new Pallet(202);
        //    var article1 = new Article("testName",10.50);
        //    pallet.PlaceArticle(article1, 3);
        //    //act
        //    pallet.RemoveArticle(article1,3);
        //    //assert
        //    Assert.AreEqual(null, pallet.Article);
        //    Assert.AreEqual(0, pallet.Amount);
        //} 
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void RemoveNegativeAmount()
        //{
        //    //arrange
        //    var pallet = new Pallet(103);
        //    var article1 = new Article("testName",10.50);
        //    pallet.PlaceArticle(article1, 4);
        //    //act
        //    pallet.RemoveArticle(article1,-3);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(4, pallet.Amount);
        //} 
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void RemoveZero()
        //{
        //    //arrange
        //    var pallet = new Pallet(1);
        //    var article1 = new Article("testName",10.50);
        //    pallet.PlaceArticle(article1, 4);
        //    //act
        //    pallet.RemoveArticle(article1,0);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(4, pallet.Amount);
        //} 
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void RemoveTooMuch()
        //{
        //    //arrange
        //    var pallet = new Pallet(19);
        //    var article1 = new Article("testName",10.50);
        //    pallet.PlaceArticle(article1, 3);
        //    //act
        //    pallet.RemoveArticle(article1,4);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(3, pallet.Amount);
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void RemoveWrongArticle()
        //{
        //    //arrange
        //    var pallet = new Pallet(19191);
        //    var article1 = new Article("testName",10.50);
        //    var article2 = new Article("testName2",10.33);
        //    pallet.PlaceArticle(article1, 3);
        //    //act
        //    pallet.RemoveArticle(article2,2);
        //    //assert
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(3, pallet.Amount);
        //}

        [TestMethod]
        public void CreatePallet()
        {
            //arrange
            //act
            var pallet = new Pallet(21);
            //assert
            Assert.IsNotNull(pallet);
            Assert.AreEqual(21, pallet.Location);
            Assert.AreEqual(0, pallet.Amount);
            Assert.AreEqual(null, pallet.Article);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatePalletWithNegativeLocation()
        {
            //arrange
            //act
            var pallet = new Pallet(-1);
            //assert
            Assert.IsNull(pallet);
        }
        
        [TestMethod]
        public void CreatePalletOverload()
        {
            //arrange
            var article1 = new Article("testName",10.50);
            //act
            var pallet = new Pallet(21, 3, article1);
            //assert
            Assert.IsNotNull(pallet);
            Assert.AreEqual(article1, pallet.Article);
            Assert.AreEqual(3, pallet.Amount);
            Assert.AreEqual(21, pallet.Location);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatePalletOverloadWithNegativeLocation()
        {
            //arrange
            var article1 = new Article("testName",10.50);
            //act
            var pallet = new Pallet(-1, 3, article1);
            //assert
            Assert.IsNull(pallet);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatePalletOverloadWithNegativeAmount()
        {
            //arrange
            var article1 = new Article("testName",10.50);
            //act
            var pallet = new Pallet(21, -1, article1);
            //assert
            Assert.IsNull(pallet);
        }
        
        [TestMethod]
        public void CreatePalletOverloadWithNullArticle()
        {
            //arrange
            //act
            var pallet = new Pallet(21, 0, null);
            //assert
            Assert.IsNotNull(pallet);
        }
        
        //[TestMethod]
        //public void CreatePalletFromDto()
        //{
        //    //arrange
        //    var article1 = new Article("testName",10.50);
        //    var dto = new PalletDto(){Location = 21, Amount = 3, Article = article1.ToDto(), Id = 5};;
        //    //act
        //    var pallet = new Pallet(dto);
        //    //assert
        //    Assert.IsNotNull(pallet);
        //    Assert.AreEqual(article1, pallet.Article);
        //    Assert.AreEqual(3, pallet.Amount);
        //    Assert.AreEqual(21, pallet.Location);
        //    Assert.AreEqual(5, pallet.Id);
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreatePalletFromDtoWithNegativeLocation()
        //{
        //    //arrange
        //    var article1 = new Article("testName",10.50);
        //    var dto = new PalletDto(){Location = -1, Amount = 3, Article = article1.ToDto(), Id = 5};;
        //    //act
        //    var pallet = new Pallet(dto);
        //    //assert
        //    Assert.IsNull(pallet);
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreatePalletFromDtoWithNegativeAmount()
        //{
        //    //arrange
        //    var article1 = new Article("testName",10.50);
        //    var dto = new PalletDto(){Location = 21, Amount = -1, Article = article1.ToDto(), Id = 5};;
        //    //act
        //    var pallet = new Pallet(dto);
        //    //assert
        //    Assert.IsNull(pallet);
        //}
        
        //test todto
        [TestMethod]
        public void TestToDto()
        {
            //arrange
            var article1 = new Article("testName",10.50);
            var pallet = new Pallet(21, 3, article1);
            //act
            var dto = pallet.ToDto();
            //assert
            Assert.IsNotNull(dto);
            Assert.AreEqual(article1.ToDto(), dto.Article);
            Assert.AreEqual(3, dto.Amount);
            Assert.AreEqual(21, dto.Location);
            Assert.AreEqual(pallet.Id, dto.Id);
        }
        
        //test todto with null article
        [TestMethod]
        public void TestToDtoWithNullArticle()
        {
            //arrange
            var pallet = new Pallet(21, 0, null);
            //act
            var dto = pallet.ToDto();
            //assert
            Assert.IsNotNull(dto);
            Assert.AreEqual(0, dto.Amount);
            Assert.AreEqual(21, dto.Location);
            Assert.AreEqual(pallet.Id, dto.Id);
        
        }

        
 
        
    }
}