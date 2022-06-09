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
            if (location < 0)
            {
                throw new ArgumentOutOfRangeException("Location can't be negative");
            }
        }
        
        public Pallet(int location, int amount, Article article)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            _palletDal = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            if(location < 0)
            {
                throw new ArgumentOutOfRangeException("Location can't be negative");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount can't be negative");
            }
        
            Location = location;
            Amount = amount;
            Article = article;
        }

        public Pallet(PalletDto palletDto)
        {
            _articleDAL = new ArticleDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            _palletDal = new PalletDAL(new SqlConnection(@"Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;"));
            if (palletDto.Location < 0)
            {
                throw new ArgumentOutOfRangeException("Location can't be negative");
            }
            Location = palletDto.Location;
            Amount = palletDto.Amount;
            PlankId = palletDto.PlankId;
            Id = palletDto.Id;
            Article = new Article(_articleDAL.GetFromPallet(palletDto));
        }
        
        
        public void PlaceArticle(Article article, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Can not add negative amount");
            }
            if (Article != null)
            {
                if (article.Id != Article.Id && Amount != 0 && article != null)
                {
                    throw new ArgumentException("Articles do not match");
                }
            }
            Amount += amount;
            Article = article;
            _palletDal.UpdatePallet(ToDto());
        }

        public void RemoveArticle(Article article, int amount)
        {
            if(article.Id != Article.Id)
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
            else
            {
                Article = article;
            }
            Amount -= amount;
            _palletDal.UpdatePallet(ToDto());
        }

        public PalletDto ToDto()
        {

            var dto = new PalletDto
            {

                Amount = Amount,
                Id = Id,
                Location = Location,
                PlankId = PlankId
            };

            if (Article != null)
            {
                dto.Article = Article.ToDto();
            }
            return dto;
        }
    }
}