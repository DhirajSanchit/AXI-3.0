using AxiDAL.DTOs;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiUnitTests.Scrubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiUnitTests.Containers
{
    [TestClass]
    public class ArticleContainerTests
    {
        [TestMethod]
        public void GetAllArticles()
        {
            //arrange
            MockFactory mockFactory = new();
            ArticleMock articleMock = new(mockFactory);
            ArticleContainer articleContainer = new(mockFactory);
            //act
            IList<Article> articles = articleContainer.GetAllArticles();
            IList<ArticleDto> dtos = articleMock.GetAll();
            //assert
            Assert.AreEqual(articles.Count(), dtos.Count());
            for(int i = 0; i <articles.Count(); i++)
            {
                Assert.AreEqual(articles[i].Id, dtos[i].Id);
            }
        }
    }
}
