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
        public int PlankId;
        public Article Article;
        public int Id;
        private IArticleDAL _articleDAL;
        private IPalletDAL _palletDal;
        
        //todo implement factory
        public Pallet(int location)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            _palletDal = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = location;
        }
        
        public Pallet(int location, int amount, Article article)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            _palletDal = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = location;
            Amount = amount;
            Article = article;
        }

        public Pallet(PalletDto palletDto)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            _palletDal = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            Location = palletDto.Location;
            Amount = palletDto.Amount;
            PlankId = palletDto.PlankId;
            Id = palletDto.Id;
            Article = new Article(_articleDAL.GetFromPallet(palletDto));
        }
        
        
        public void PlaceArticle(Article article, int amount)
        {
            if (article.Id != Article.Id && Amount != 0 && article != null) 
            {
                throw new ArgumentException("Articles do not match");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Can not add negative amount");
            }
            Amount += amount;
            Article = article;
            _palletDal.UpdatePallet(ToDto());
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
            return new PalletDto {Article = Article.ToDto(),
                                  Amount = Amount,
                                  Id = Id,
                                  Location = Location,
                                  PlankId = PlankId
            };
        }
    }
}