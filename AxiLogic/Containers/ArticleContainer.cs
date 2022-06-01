using System.Collections.Generic;
using AxiLogic.Classes;
using System;
using System.Collections;
using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Interfaces;

namespace AxiLogic.Containers
{
    public class ArticleContainer : IArticleContainer
    {
        private IList<Article> _articles; 
        private IDalFactory _idalFactory;
        
        public ArticleContainer(DalFactory idalFactory)
        {
            _idalFactory = idalFactory;
        }

        public IList<Article> GetArticles()
        {
            
            return _articles;
        }

        public IList<Article> GetArticlesByCategory(CategoryDto categoryDto)
        {
            var articleDtOs = _idalFactory.GetArticleDal().GetByCategory(categoryDto);
            List<Article> articles = new();
            foreach (var articleDto in articleDtOs)
            {
                articles.Add(new Article(articleDto));
            }
            return _articles = articles;
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
            article.Id = _idalFactory.GetArticleDal().AddArticle(articleDto);
            _articles.Add(article);
        }
        
        public void RemoveArticle(Article article)
        {
            if (!_articles.Contains(article))
            {
                throw new ArgumentException("Article does not exist");
            }

            _idalFactory.GetArticleDal().DeleteArticle(article.ToDto());
            _articles.Remove(article);
        }
        
        public void ClearArticles()
        {
            _articles.Clear();
        }
        
        public ArticleDto GetArticleById(int articleID)
        {
            return _idalFactory.GetArticleDal().GetArticleById(articleID);
        }
        
        public IList<Article> GetAllArticles()
        {
            var articleDTOs = _idalFactory.GetArticleDal().GetAll();
            List<Article> articles = new();
            foreach (var articleDTO in articleDTOs)
            {
                articles.Add(new Article(articleDTO));
            }

            return _articles = articles;
        }
        
        public void RemoveCategoryFromArticles(CategoryDto categoryDto)
        {
            var articleDtOs = _idalFactory.GetArticleDal().GetByCategory(categoryDto);
            List<Article> articles = new();
            foreach (var articleDto in articleDtOs)
            {
                var article = new Article(articleDto);
                article.Category = null;
                _idalFactory.GetArticleDal().RemoveCategory(article.ToDto());
            }
        }
        
        public void removeCategoryFromArticles(int categoryId)
        {
            var articleDtOs = _idalFactory.GetArticleDal().GetByCategory(new CategoryDto() { Id = categoryId });
            foreach (var articleDto in articleDtOs)
            {
                var article = new Article(articleDto);
                article.Category = null;
                _idalFactory.GetArticleDal().RemoveCategory(article.ToDto());
            }
        }
    
        public void UpdateArticle(Article article)
        {
            if (!_articles.Contains(article))
            {
                throw new ArgumentException("Article does not exist");
            }
            _idalFactory.GetArticleDal().UpdateArticle(article.ToDto());
        }
    }
}