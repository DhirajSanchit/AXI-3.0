using System;
using System.Linq;
using Axi3._0;
using AxiLogic.Classes;
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
            Toolbox.ArticleContainer.ClearArticles();
            var article1 = new Article();
            //act
            Toolbox.ArticleContainer.AddArticle(article1);
            //assert
            Assert.IsTrue(Toolbox.ArticleContainer.GetArticles().Contains(article1),"Article1 not found in Article list");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateArticleTest()
        {
            //arrange
            Toolbox.ArticleContainer.ClearArticles();
            var article1 = new Article(); 
            Toolbox.ArticleContainer.AddArticle(article1);
            //act
            Toolbox.ArticleContainer.AddArticle(article1);
            //assert
            Assert.AreEqual(1, Toolbox.ArticleContainer.GetArticles().Count,"Adding duplicate was allowed");
        }
        
        [TestMethod]
        public void RemoveArticleTest()
        {
            //arrange
            Toolbox.ArticleContainer.ClearArticles();
            var article1 = new Article();
            var article2 = new Article();
            var article3 = new Article();
            Toolbox.ArticleContainer.AddArticle(article1);
            Toolbox.ArticleContainer.AddArticle(article2);
            Toolbox.ArticleContainer.AddArticle(article3);
            //act
            
            Toolbox.ArticleContainer.RemoveArticle(article2);
            //assert
            Assert.AreEqual(2, Toolbox.ArticleContainer.GetArticles().Count,"Article was not removed");
            Assert.IsTrue( Toolbox.ArticleContainer.GetArticles().Contains(article1),"Article 1 not found");
            Assert.IsFalse( Toolbox.ArticleContainer.GetArticles().Contains(article2),"Article 2 should not be found");
            Assert.IsTrue( Toolbox.ArticleContainer.GetArticles().Contains(article3),"Article 3 not found");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonContainedArticle()
        {
            //arrange
            Toolbox.ArticleContainer.ClearArticles();
            var article1 = new Article(); 
            var article2 = new Article(); 
            Toolbox.ArticleContainer.AddArticle(article1);
            //act
            Toolbox.ArticleContainer.RemoveArticle(article2);
            //assert
            Assert.AreEqual(1, Toolbox.ArticleContainer.GetArticles().Count,"Wrong article was removed");
        }
    }
}