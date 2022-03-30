using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IArticleDAL
    {
        public IList<ArticleDto> GetAll();
        public ArticleDto GetById();
        public bool AddArticle();
    }
}