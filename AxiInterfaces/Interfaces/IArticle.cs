using AxiInterfaces.DTOs;

namespace AxiInterfaces.Interfaces
{
    public interface IArticle
    {
        void AddArticle(ArticleDto articleDto);
        void RemoveArticle(ArticleDto articleDto);
        void ClearArticles(ArticleDto articleDto);
    }
}