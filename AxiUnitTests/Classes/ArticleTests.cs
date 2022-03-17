using System;
using AxiLogic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.Classes
{
    [TestClass]
    public class ArticleTests
    {
        [TestMethod]
        public void CreateArticle()
        {
            //arrange
            var name = "articleName";
            var price = 10.50;
            //act
            var article = new Article(name,price);
            //assert
            Assert.IsTrue(article.Name == name);
            Assert.IsTrue(Math.Abs(article.Price - price) < 0.0001);
        }
    }
}