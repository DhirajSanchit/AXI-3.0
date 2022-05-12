using System.Collections.Generic;
using AxiLogic.Classes;
using System;
using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Interfaces;

namespace AxiLogic.Containers
{
    public class ArticleContainer : IArticleContainer
    {
        private List<Article> _articles; 
        private DalFactory _dalFactory;
        
        public ArticleContainer(DalFactory dalFactory)
        {
            
            /**
             *factory = factory;
            _articles = new List<Article>();
            iArticleDAL = dal;
            foreach (var articleDto in factory.GetArticleDal().GetAll())
            {
                _articles.Add(new Article(articleDto));
            }
             * 
             **/
            
            _dalFactory = dalFactory;
        }

        public ArticleContainer()
        {
            
        }
        
        public IReadOnlyCollection<Article> GetArticles()
        {
            return _articles;
        }
        
        public void AddArticle(Article article)
        {
            if (_articles.Contains(article))
            {
                throw new ArgumentException("Cannot add duplicate article");
            }
            var articleDto = new ArticleDto()
            {
                Name = article.Name,
                Price = article.Price,
                Barcode = article.Barcode,
                ImgRef = article.ImgRef,
                Description = article.Description,
                Category = article.Category
            };
            article.Id = _dalFactory.GetArticleDal().AddArticle(articleDto);
            _articles.Add(article);
        }
        
        public void RemoveArticle(Article article)
        {
            if (!_articles.Contains(article))
            {
                throw new ArgumentException("Article does not exist");
            }

            _dalFactory.GetArticleDal().DeleteArticle(article.ToDto());
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
            var articleDTOs = _dalFactory.GetArticleDal().GetAll();
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
        
    
        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}