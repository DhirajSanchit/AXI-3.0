using System.Collections.Generic;
using System.Data;
using AxiDAL.DTOs;

namespace AxiLogic.Interfaces
{
    public interface IArticleContainer
    {
        public IList<ArticleDto> GetAll();
        public ArticleDto GetById();
        public bool AddArticle();
    }
}