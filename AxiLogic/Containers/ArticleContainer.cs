using System.Collections.Generic;
using AxiLogic.Classes;

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
            _articles.Add(article);
        }

        public void RemoveArticle(Article article)
        {
            _articles.Remove(article);
        }
        
    }
}