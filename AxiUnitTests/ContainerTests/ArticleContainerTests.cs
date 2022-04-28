using System;
using System.Collections.Generic;
using System.Linq;
using AxiDAL.DTOs;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiUnitTests.Scrubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AxiUnitTests.ContainerTests
{
    [TestClass]
    public class ArticleContainerTests
    {

        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            ArticleScrub dal = new();
            //Assert
            var container = new ArticleContainer(dal);
            //Act
            Assert.IsNotNull(container, "container = null");
        }
        
        [TestMethod]
        public void AddArticleTest()
        {
            //arrange
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            var article1 = new Article("testName",10.50);
            //act
            container.AddArticle(article1);
            //assert
            Assert.IsTrue(container.GetArticles().Contains(article1),"Article1 not found in Article list");
            Assert.IsTrue(dal._articleDtos.Contains(article1.ToDto()));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateArticleTest()
        {
            //arrange
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            var article1 = new Article("testName",10.50);
            var expectedAmount = container.GetArticles().Count + 1;
            container.AddArticle(article1);
            //act
            container.AddArticle(article1);
            //assert
            Assert.AreEqual(expectedAmount, container.GetArticles().Count,"Adding duplicate was allowed");
            Assert.AreEqual(expectedAmount, dal._articleDtos.Count, "Adding duplicate was allowed");
        }
        
        [TestMethod]
        public void RemoveArticleTest()
        {
            //arrange
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            var article1 = new Article("testName",10.50);
            var article2 = new Article("testName2",10.33);
            var article3 = new Article("testName3",10.99);
            container.AddArticle(article1);
            container.AddArticle(article2);
            container.AddArticle(article3);
            //act
            container.RemoveArticle(article2);
            //assert
            Assert.IsTrue( container.GetArticles().Contains(article1),"Article 1 should not be removed");
            Assert.IsFalse( container.GetArticles().Contains(article2),"Article 2 should be removed");
            Assert.IsTrue( container.GetArticles().Contains(article3),"Article 3 should not be removed");
            Assert.IsTrue(dal._articleDtos.Contains(article1.ToDto()), "Article 1 should not be removed from database");
            Assert.IsFalse(dal._articleDtos.Contains(article2.ToDto()), "Article 2 should be removed from database");
            Assert.IsTrue(dal._articleDtos.Contains(article3.ToDto()), "Article 3 should not be removed from database");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonContainedArticle()
        {
            //arrange
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            var article1 = new Article("testName",10.50); 
            var article2 = new Article("testName2",10.33); 
            container.AddArticle(article1);
            //act
            container.RemoveArticle(article2);
            //assert
            Assert.IsTrue(container.GetArticles().Contains(article1),"Wrong article was removed");
        }

        [TestMethod]
        public void ClearArticleTest()
        {
            //arrange
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            var article1 = new Article("testName",10.50); 
            var article2 = new Article("testName2",10.33); 
            container.AddArticle(article1);
            container.AddArticle(article2);
            //act
            container.ClearArticles();
            //assert
            Assert.AreEqual(0, container.GetArticles().Count, "Articles weren't cleared");
            Assert.IsFalse(dal._articleDtos.Count==0,"Articles should not be removed from database");
        }

        [TestMethod]
        public void GetArticleByValidId()
        {
            //arrange
            var validId = 1;
            ArticleScrub dal = new();
            var expectedResult = new ArticleDto();
            foreach (var dto in dal._articleDtos)
            {
                if (dto.Id == validId)
                {
                    expectedResult = dto;
                }
            }
            
            var container = new ArticleContainer(dal);
            //act
            var result = container.GetArticleById(validId);
            //assert
            Assert.AreEqual(expectedResult, result.ToDto());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetArticleByInValidId()
        {
            //arrange
            var inValidId = 999;
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            //act
            var result = container.GetArticleById(inValidId);
            //assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetAllArticles()
        {
            //Arrange
            ArticleScrub dal = new();
            var container = new ArticleContainer(dal);
            //Act
            container.GetAllArticles();
            //Assert
            List<Article> articles = new();
            foreach (var articleDTO in dal._articleDtos)
            {
                articles.Add(new Article(articleDTO));
            }
            Assert.AreEqual(articles, container.GetArticles());
        }
    }
}