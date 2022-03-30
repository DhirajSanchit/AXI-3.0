using System;
using System.Collections.Generic;
using AxiInterfaces.DTOs;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class ArticleViewModel
    {
       public readonly List<ArticleModel> ArticleModels= new ();
       
       public void GetArticleModels()
       {
           ArticleModels.Clear();
           var articles = Toolbox.ArticleContainer.GetArticles();
           foreach (var article in articles)
           {
               ArticleModels.Add(new ArticleModel()
               {
                   Name = article.Name,
                   Id = article.Id,
                   Category = article.Category,
                   Barcode = article.Barcode,
                   ImgRef = article.ImgRef,
                   Description = article.Description,
                   Price = article.Price
               });
           }
       }

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
               Category = Enum.Parse<Category>(category), 
               Description = description
           };
           ArticleModels.Add(articleModel);
           //todo call onto DAL
           Toolbox.ArticleContainer.AddArticle(new Article(articleDto));
       }
       
    }
}