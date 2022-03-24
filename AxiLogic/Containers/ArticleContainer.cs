using System.Collections.Generic;
using AxiLogic.Classes;
using System;

namespace AxiLogic.Containers
{
    public class ArticleContainer
    {
        private List<Article> _articles;

        public ArticleContainer()
        {
            _articles = new List<Article>();
        }

        public IReadOnlyCollection<Article> GetArticles()
        {
            return _articles;
        }
        
        public void AddArticle(Article article)
        {
            if (_articles.Contains(article))
            {
                throw new ArgumentException("Can not add duplicate article");
            }
            _articles.Add(article);
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
        
        //Test function | dumped later
        // public void CreateRandomContent() //todo test function delete later
        // {
        //     var rand = new Random();
        //     for (var i=0; i<21; i++)
        //     {
        //         _articles.Add(new Article(rand.Next(0, 100).ToString(), rand.Next(1, 100))); 
        //     }
        // }
    }
}