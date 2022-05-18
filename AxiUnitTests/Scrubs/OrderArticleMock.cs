using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class OrderArticleMock : IOrderArticleDAL
    {
        public List<OrderArticleDto> OrderArticleDtos = new();
        private IDalFactory _mockFactory;

        public OrderArticleMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
            OrderArticleDtos.Add(new OrderArticleDto()
            {
                Amount = 5,
                Article = _mockFactory.GetArticleDal().GetAll()[0],
                ArticleId = 1,
                OrderId = 11,
                ScannedAmount = 3,
            });
            OrderArticleDtos.Add(new OrderArticleDto()
            {
                Amount = 5,
                Article = _mockFactory.GetArticleDal().GetAll()[1],
                ArticleId = 2,
                OrderId = 12,
                ScannedAmount = 5,
            });
        }

        public IList<OrderArticleDto> GetAllOrderArticlesFromOrder(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public int AddOrderArticle(OrderArticleDto orderArticle)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrderArticle(OrderArticleDto orderArticle)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOrderArticle(OrderArticleDto orderArticle)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrderArticleProgress(OrderArticleDto orderArticleDto)
        {
            throw new System.NotImplementedException();
        }
    }
}