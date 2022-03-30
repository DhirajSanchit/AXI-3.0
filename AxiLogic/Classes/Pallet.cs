using System.Collections.Generic;
using System;
using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class Pallet
    {
        public int Location;
        public int Amount { get; private set; }
        public Article Article { get; private set; }
        
        public Pallet(){}
        
        public Pallet(int location)
        {
            Location = location;
        }
        
        public Pallet(int location, int amount, Article article)
        {
            Location = location;
            Amount = amount;
            Article = article;
        }

        public Pallet(PalletDto palletDto)
        {
            Location = palletDto.Location;
            Amount = palletDto.Amount;
            Article = new Article(palletDto.Article);
        }
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