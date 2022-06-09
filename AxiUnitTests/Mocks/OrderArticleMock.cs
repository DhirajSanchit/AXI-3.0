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
                Amount = 11,
                Article = _mockFactory.GetArticleDal().GetAll()[0],
                ArticleId = 1,
                OrderId = 1,
                ScannedAmount = 1
            });
            OrderArticleDtos.Add(new OrderArticleDto()
            {
                Amount = 12,
                Article = _mockFactory.GetArticleDal().GetAll()[1],
                ArticleId = 2,
                OrderId = 2,
                ScannedAmount = 2
            });
        }

        public IList<OrderArticleDto> GetAllOrderArticlesFromOrder(OrderDto order)
        {
            List<OrderArticleDto> returnList = new();
            foreach (var dto in OrderArticleDtos)
            {
                if (dto.OrderId == order.Id)
                {
                    returnList.Add(dto); ;
                }
            }
            return returnList;
        }

        public void AddOrderArticle(OrderArticleDto orderArticle)
        {
            OrderArticleDtos.Add(orderArticle);
        }

        public void UpdateOrderArticle(OrderArticleDto orderArticle)
        {
            foreach (var dto in OrderArticleDtos)
            {
                if (dto.ArticleId != orderArticle.ArticleId || dto.OrderId != orderArticle.OrderId) continue;
                OrderArticleDtos.Remove(dto);
                OrderArticleDtos.Add(orderArticle);
            }
        }

        public void DeleteOrderArticle(OrderArticleDto orderArticle)
        {
            OrderArticleDtos.Remove(orderArticle);
        }

        public void UpdateOrderArticleProgress(OrderArticleDto orderArticleDto)
        {
            foreach (var dto in OrderArticleDtos)
            {
                if (dto.ArticleId == orderArticleDto.ArticleId && dto.OrderId == orderArticleDto.OrderId)
                {
                    dto.Amount = orderArticleDto.Amount;
                }
            }
        }
    }
}