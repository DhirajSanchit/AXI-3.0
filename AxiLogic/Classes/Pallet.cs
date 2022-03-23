using AxiInterfaces.DTOs;
using System.Collections.Generic;
using System;

namespace AxiLogic.Classes
{
    public class Pallet
    {
        public int Location;
        public int Amount { get; private set; }
        public Article Article { get; private set; }

        public void PlaceArticle(Article article, int amount)
        {
            if (article != Article && Amount != 0) 
            {
                throw new ArgumentException("Articles do not match");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount");
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

        public PalletDto ToDto()
        {
            ArticleDto articleDto = new();
            Article.ToDto();
            return new PalletDto {Article = articleDto,
                                  Amount = Amount};
        }
    }
}