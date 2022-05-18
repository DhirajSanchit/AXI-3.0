using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IOrderArticleDAL
    {
        public IList<OrderArticleDto> GetAllOrderArticlesFromOrder(OrderDto order);
        public void AddOrderArticle(OrderArticleDto orderArticle);
        public void UpdateOrderArticle(OrderArticleDto orderArticle);
        public void DeleteOrderArticle(OrderArticleDto orderArticle);
        public void UpdateOrderArticleProgress(OrderArticleDto orderArticleDto);
    }
}