using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IArticleDAL
    {
        public IList<ArticleDto> GetAll();
        public ArticleDto GetByBarcode(ArticleDto articleDto);
        public int AddArticle(ArticleDto articleDto);

        public bool UpdateArticle(ArticleDto articleDto);
        public bool DeleteArticle(ArticleDto articleDto);
    }
}