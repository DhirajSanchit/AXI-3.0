using System;
using System.Linq;
using Axi3._0;
using AxiLogic.Classes;
using AxiLogic.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.ContainerTests
{
    [TestClass]
    public class ArticleContainerTests
    {
        [TestMethod]
        public void AddArticleTest()
        {
            //arrange
            var container = new ArticleContainer();
            var article1 = new Article("testName",10.50);
            //act
            container.AddArticle(article1);
            //assert
            Assert.IsTrue(container.GetArticles().Contains(article1),"Article1 not found in Article list");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateArticleTest()
        {
            //arrange
            var container = new ArticleContainer();
            var article1 = new Article("testName",10.50); 
            container.AddArticle(article1);
            //act
            container.AddArticle(article1);
            //assert
            Assert.AreEqual(1, container.GetArticles().Count,"Adding duplicate was allowed");
        }
        
        [TestMethod]
        public void RemoveArticleTest()
        {
            //arrange
            var container = new ArticleContainer();
            var article1 = new Article("testName",10.50);
            var article2 = new Article("testName2",10.33);
            var article3 = new Article("testName3",10.99);
            container.AddArticle(article1);
            container.AddArticle(article2);
            container.AddArticle(article3);
            //act
            
            container.RemoveArticle(article2);
            //assert
            Assert.AreEqual(2, container.GetArticles().Count,"Article was not removed");
            Assert.IsTrue( container.GetArticles().Contains(article1),"Article 1 not found");
            Assert.IsFalse( container.GetArticles().Contains(article2),"Article 2 should not be found");
            Assert.IsTrue( container.GetArticles().Contains(article3),"Article 3 not found");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonContainedArticle()
        {
            //arrange
            var container = new ArticleContainer();
            var article1 = new Article("testName",10.50); 
            var article2 = new Article("testName2",10.33); 
            container.AddArticle(article1);
            //act
            container.RemoveArticle(article2);
            //assert
            Assert.AreEqual(1, container.GetArticles().Count,"Wrong article was removed");
        }
    }
}