using System;
using System.ComponentModel;
using AxiDAL.DTOs;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class ArticleTests
    {

        [TestCategory("ArticleTests-ConstructorNamePrice"), TestMethod]
        public void TestArticleConstructor()
        {
            //arrange
            var name = "articleName";
            var price = 10.50;
            //act
            var article = new Article(name, price);
            //assert
            Assert.AreEqual(name, article.Name);
            Assert.AreEqual(name, article.Name);
        }

        [TestCategory("ArticleTests-ConstructorNamePrice"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleConstructorWithNullName()
        {
            //arrange
            var price = 10.50;
            //act
            var article = new Article(null, price);
            //assert
            Assert.AreEqual(null, article);
        }

        [TestCategory("ArticleTests-ConstructorNamePrice"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleConstructorWithEmptyName()
        {
            //arrange
            var name = "";
            var price = 10.50;
            //act
            var article = new Article(name, price);
            //assert
            Assert.AreEqual(null, article);
        }

        [TestCategory("ArticleTests-ConstructorNamePrice"), TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArticleConstructorWithNegativePrice()
        {
            //arrange
            var name = "articleName";
            var price = -10.50;
            //act
            var article = new Article(name, price);
            //assert
            Assert.AreEqual(null, article);
        }

        //params string name, double price, string barcode, string imgRef, string description, string category
        [TestCategory("ArticleTests-ConstructorOverload"), TestMethod]
        public void TestArticleConstructorOverload()
        {
            //arrange
            var name = "articleName";
            var price = 10.50;
            var barcode = "barcode";
            var imgRef = "imgRef";
            var description = "description";
            var category = "category";
            //act
            var article = new Article(name, price, barcode, imgRef, description, category);
            //assert
            Assert.AreEqual(name, article.Name);
            Assert.AreEqual(price, article.Price);
            Assert.AreEqual(barcode, article.Barcode);
            Assert.AreEqual(imgRef, article.ImgRef);
            Assert.AreEqual(description, article.Description);
            Assert.AreEqual(category, article.Category);
        }

        [TestCategory("ArticleTests-ConstructorOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleConstructorOverloadWithNullName()
        {
            //arrange
            var price = 10.50;
            var barcode = "barcode";
            var imgRef = "imgRef";
            var description = "description";
            var category = "category";
            //act
            var article = new Article(null, price, barcode, imgRef, description, category);
            //assert
            Assert.AreEqual(null, article);
        }

        [TestCategory("ArticleTests-ConstructorOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleConstructorOverloadWithEmptyName()
        {
            //arrange
            var name = "";
            var price = 10.50;
            var barcode = "barcode";
            var imgRef = "imgRef";
            var description = "description";
            var category = "category";
            //act
            var article = new Article(name, price, barcode, imgRef, description, category);
            //assert
            Assert.AreEqual(null, article);
        }
        
        [TestCategory("ArticleTests-ConstructorOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArticleConstructorOverloadWithNegativePrice()
        {
            //arrange
            var name = "articleName";
            var price = -10.50;
            var barcode = "barcode";
            var imgRef = "imgRef";
            var description = "description";
            var category = "category";
            //act
            var article = new Article(name, price, barcode, imgRef, description, category);
            //assert
            Assert.AreEqual(null, article);
        }
        
        [TestCategory("ArticleTests-ConstructorDto"), TestMethod]
        public void TestArticleConstructorDto()
        {
            //arrange
            var dto = new ArticleDto
            {
                Name = "articleName",
                Price = 10.50,
                Barcode = "barcode",
                ImgRef = "imgRef",
                Description = "description",
                CategoryName = "category"
            };
            //act
            var article = new Article(dto);
            //assert
            Assert.AreEqual(dto.Name, article.Name);
            Assert.AreEqual(dto.Price, article.Price);
            Assert.AreEqual(dto.Barcode, article.Barcode);
            Assert.AreEqual(dto.ImgRef, article.ImgRef);
            Assert.AreEqual(dto.Description, article.Description);
            Assert.AreEqual(dto.CategoryName, article.Category);
        }

        [TestCategory("ArticleTests-ConstructorDto"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleConstructorDtoWithNullName()
        {
            //arrange
            var dto = new ArticleDto
            {
                Name = null,
                Price = 10.50,
                Barcode = "barcode",
                ImgRef = "imgRef",
                Description = "description",
                CategoryName = "category"
            };
            //act
            var article = new Article(dto);
            //assert
            Assert.AreEqual(null, article);
        }
        
        [TestCategory("ArticleTests-ConstructorDto"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleConstructorDtoWithEmptyName()
        {
            //arrange
            var dto = new ArticleDto
            {
                Name = "",
                Price = 10.50,
                Barcode = "barcode",
                ImgRef = "imgRef",
                Description = "description",
                CategoryName = "category"
            };
            //act
            var article = new Article(dto);
            //assert
            Assert.AreEqual(null, article);
        }
        
        [TestCategory("ArticleTests-ConstructorDto"), TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArticleConstructorDtoWithNegativePrice()
        {
            //arrange
            var dto = new ArticleDto
            {
                Name = "articleName",
                Price = -10.50,
                Barcode = "barcode",
                ImgRef = "imgRef",
                Description = "description",
                CategoryName = "category"
            };
            //act
            var article = new Article(dto);
            //assert
            Assert.AreEqual(null, article);
        }
        
        [TestCategory("ArticleTests-SetName"), TestMethod]
        public void TestArticleSetName()
        {
            //arrange
            var article = new Article("wrongName", 10.50);
            var name = "articleName";
            //act
            article.SetName(name);
            //assert
            Assert.AreEqual(name, article.Name);
        }
        
        [TestCategory("ArticleTests-SetName"), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestArticleSetNameWithEmptyName()
        {
            //arrange
            var correctName = "articleName";
            var article = new Article(correctName, 10.50);
            var wrongName = "";
            //act
            article.SetName(wrongName);
            //assert
            Assert.AreEqual(correctName, article.Name);
        }

        //test set description
        [TestCategory("ArticleTests-SetDescription"), TestMethod]
        public void TestArticleSetDescription()
        {
            //arrange
            var article = new Article("articleName", 10.50);
            var description = "description";
            //act
            article.SetDescription(description);
            //assert
            Assert.AreEqual(description, article.Description);
        }
        
        [TestCategory("ArticleTests-SetCategory"), TestMethod]
        public void TestArticleSetCategory()
        {
            //arrange
            var article = new Article("articleName", 10.50);
            var category = "category";
            //act
            article.SetCategory(category);
            //assert
            Assert.AreEqual(category, article.Category);
        }
        
        //test set price
        [TestCategory("ArticleTests-SetPrice"), TestMethod]
        public void TestArticleSetPrice()
        {
            //arrange
            var article = new Article("articleName", 10.50);
            var price = 20.50;
            //act
            article.SetPrice(price);
            //assert
            Assert.AreEqual(price, article.Price);
        }
        
        [TestCategory("ArticleTests-SetPrice"), TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArticleSetPriceWithNegativePrice()
        {
            //arrange
            var article = new Article("articleName", 10.50);
            var price = -10.50;
            //act
            article.SetPrice(price);
            //assert
            Assert.AreEqual(10.50, article.Price);
        }
        
        //test set barcode
        [TestCategory("ArticleTests-SetBarcode"), TestMethod]
        public void TestArticleSetBarcode()
        {
            //arrange
            var article = new Article("articleName", 10.50);
            var barcode = "barcode";
            //act
            article.SetBarcode(barcode);
            //assert
            Assert.AreEqual(barcode, article.Barcode);
        }
        
        //test set img
        [TestCategory("ArticleTests-SetImg"), TestMethod]
        public void TestArticleSetImg()
        {
            //arrange
            var article = new Article("articleName", 10.50);
            var img = "img";
            //act
            article.SetImg(img);
            //assert
            Assert.AreEqual(img, article.ImgRef);
        }
        
        //test toDto
        [TestCategory("ArticleTests-ToDto"), TestMethod]
        public void TestArticleToDto()
        {
            //arrange
            var article = new Article("articleName", 10.50, "barCode", "description", "category", "img");
            var dto = new ArticleDto();
            //act
            dto = article.ToDto();
            //assert
            Assert.AreEqual(article.Name, dto.Name);
            Assert.AreEqual(article.Price, dto.Price);
            Assert.AreEqual(article.Barcode, dto.Barcode);
            Assert.AreEqual(article.ImgRef, dto.ImgRef);
            Assert.AreEqual(article.Description, dto.Description);
            Assert.AreEqual(article.Category, dto.CategoryName);
        }
    }
}




  