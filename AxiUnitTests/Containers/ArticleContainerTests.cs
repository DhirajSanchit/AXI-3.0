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
            ArticleContainer articleContainer = new(mockFactory);
            var dtos = mockFactory.ArticleMock._articleDtos;
            //act
            var articles = articleContainer.GetAllArticles();
            //assert
            Assert.AreEqual(articles.Count(), dtos.Count());
            for(var i = 0; i <articles.Count(); i++)
            {
                Assert.AreEqual(articles[i].Id, dtos[i].Id);
            }
        }
    }
}
