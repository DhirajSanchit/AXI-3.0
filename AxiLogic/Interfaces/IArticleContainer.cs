using System.Collections.Generic;
using System.Data;
using AxiDAL.DTOs;
using AxiLogic.Classes;

namespace AxiLogic.Interfaces
{
    public interface IArticleContainer
    {
        public IList<Article> GetAllArticles();
        
        //public void GetAllArticles();
        public ArticleDto GetArticleById(int articleID);
        public void AddArticle(Article article);
        public void RemoveArticle(Article article);
        public void UpdateArticle(Article article);
        
        
        
        
    }
}