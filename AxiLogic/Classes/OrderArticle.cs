using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class OrderArticle
    {
        public int Amount { get; private set; }
        public Article Article { get; private set; }
        public int OrderId { get; private set; }

        public int ScannedAmount { get; private set; }
        public OrderArticle(int orderId)
        {
            OrderId = orderId;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public void SetArticle(Article article)
        {
            Article = article;
        }

        public OrderArticleDto ToDto()
        {
            ArticleDto articleDto = new();
            Article.ToDto();
            return new OrderArticleDto
            {
                Article = articleDto,
                Amount = Amount,
                OrderId = OrderId
            };
        }
    }
}