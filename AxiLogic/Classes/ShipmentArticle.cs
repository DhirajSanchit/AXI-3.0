

namespace AxiLogic.Classes
{
    public class ShipmentArticle
    {
        public int Amount { get; private set; }
        public Article Article { get; private set; } 
        public int Id { get; private set; }
 
        public ShipmentArticle(int id)
        {
            Id = id;
        }
        
        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public void SetArticle(Article article)
        {
            Article = article;
        }
    }
}