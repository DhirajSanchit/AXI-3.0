using System.Collections.Generic;
using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class ArticleViewModel
    {
       public List<ArticleModel> ArticleModels= new ();
       
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
    }
}