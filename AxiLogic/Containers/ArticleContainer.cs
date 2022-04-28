using System.Collections.Generic;
using AxiLogic.Classes;
using System;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiLogic.Containers
{
    public class ArticleContainer
    {
        private List<Article> _articles;
        private IArticleDAL iArticleDAL;

        public ArticleContainer(IArticleDAL context)
        {
            iArticleDAL = context;
            _articles = new List<Article>();
            foreach (var articleDto in iArticleDAL.GetAll())
            {
                _articles.Add(new Article(articleDto));
            }
        }

        public IReadOnlyCollection<Article> GetArticles()
        {
            return _articles;
        }

        public void AddArticle(Article article)
        {
            ArticleDto articleDto = new ArticleDto()
            {
                Name = article.Name,
                Price = article.Price,
                Barcode = article.Barcode,
                ImgRef = article.ImgRef,
                Description = article.Description,
                Category = article.Category
            }; 
            iArticleDAL.AddArticle(articleDto);
        }

        public void RemoveArticle(Article article)
        {
            if (!_articles.Contains(article))
            {
                throw new ArgumentException("Article does not exist");
            }

            _articles.Remove(article);
        }

        public void ClearArticles()
        {
            _articles.Clear();
        }

        public Article GetArticleById(int articleID)
        {
            foreach (var article in _articles)
            {
                if (article.Id == articleID)
                {
                    return article;
                }
            }

            return null;
        }

        public void GetAllArticles()
        {
            var articleDTOs = iArticleDAL.GetAll();
            List<Article> articles = new();
            foreach (var articleDTO in articleDTOs)
            {
                articles.Add(new Article(articleDTO));
            }

            _articles = articles;
        }

        // public Article AddArticle()
        // {
        //     
        // }
        
        // public IList<ArticleDto> GetAll()
        // {
        //     throw new NotImplementedException();
        // }
       
        // public ArticleDto GetById()
        // {
        //     throw new NotImplementedException();
        // }
        
        // public bool AddArticle()
        // {
        //     throw new NotImplementedException();
        // }
       
        // public bool DeleteArticle()
        // {
        //     throw new NotImplementedException();
        // }
        
        // public bool UpdateArticle()
        // {
        //     throw new NotImplementedException();
        // }
    }
}