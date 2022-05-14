using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IArticleDAL
    {
        public IList<ArticleDto> GetAll();
        public ArticleDto GetByBarcode(ArticleDto articleDto);
        public int AddArticle(ArticleDto articleDto);

        public void UpdateArticle(ArticleDto articleDto);
        public void DeleteArticle(ArticleDto articleDto);
        public ArticleDto GetFromPallet(PalletDto palletDto);
        public List<ArticleDto> GetByCategory(CategoryDto categoryDto);
        public void RemoveCategory(ArticleDto articleDto);
    }
}