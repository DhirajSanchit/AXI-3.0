using System;

namespace AxiLogic.Classes
{
    public class Pallet
    {
        public int Amount { get; private set; }
        public Article Article { get; private set; } = new();

        public void PlaceArticle(Article article, int amount)
        {
            if (article != Article && Amount != 0) 
            {
                throw new ArgumentException("Articles do not match");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount can not be negative");
            }
            Amount += amount;
            Article = article;
        }

        public void RemoveArticle(Article article, int amount)
        {
            if(article != Article || Amount < amount)
            {
                throw new ArgumentException("Articles do not match or not enough articles");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            Amount -= amount;
        }
    }
}