using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class ArticleViewModel
    { 
        
        public IList<Article> ArticleModels;
        
       public void CreateArticle(string name, double price, string imgRef, string categoryname, int categoryid, string description, bool disabled)
       {
           var articleDto = new ArticleDto()
           {
               Name = name,
               Price = price,
               Img = imgRef,
               CategoryName = categoryname,
               CategoryId =  categoryid,
               Description = description,
               Disabled = disabled
               
               
           };
           var articleModel = new ArticleModel()
           {
               Name = name,
               Price = price,
               ImgRef = imgRef,
               CategoryName = categoryname,
               CategoryId = categoryid,
               Description = description,
               Disabled = disabled
           };
           //ArticleModels.Add(articleModel);
           //ContainerFactory.ArticleContainer.AddArticle(new Article(articleDto));
       }
       
    }
}