using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using AxiDAL.DAL;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiLogic.Classes
{
    public class Pallet
    {
        public int Location;
        public int Amount;
        public Article Article;
        public int Id;
        private IArticleDAL _articleDAL;
        
        //todo implement factory
        public Pallet(int location)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = location;
        }
        
        public Pallet(int location, int amount, Article article)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));

            Location = location;
            Amount = amount;
            Article = article;
        }

        public Pallet(PalletDto palletDto)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = palletDto.Location;
            Amount = palletDto.Amount;
            Article = new Article(_articleDAL.GetFromPallet(palletDto));
        }
        
        
        public void PlaceArticle(Article article, int amount)
        {
            if (article != Article && Amount != 0) 
            {
                throw new ArgumentException("Articles do not match");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Can not add negative amount");
            }
            Amount += amount;
            Article = article;
        }

        public void RemoveArticle(Article article, int amount)
        {
            if(article != Article)
            {
                throw new ArgumentException("Articles do not match");
            }
            if (Amount < amount)
            {

                throw new ArgumentOutOfRangeException("Not enough articles to remove");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Can not remove negative amount");
            }
            if (Amount - amount == 0)
            {
                Article = null;
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