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
        
        public readonly IList<ArticleModel> _articleModels;
        
       public void CreateArticle(string name, double price, string imgRef, string category, string description)
       {
           var articleDto = new ArticleDto()
           {
               Name = name,
               Price = price,
               ImgRef = imgRef,
               Category = category,
               Description = description
           };
           var articleModel = new ArticleModel()
           {
               Name = name,
               Price = price,
               ImgRef = imgRef,
               Category = category, 
               Description = description
           };
           _articleModels.Add(articleModel);
           //ContainerFactory.ArticleContainer.AddArticle(new Article(articleDto));
       }
       
    }
}