using AxiDAL.DTOs;
using System.Collections.Generic;

namespace AxiDAL.Interfaces
{
    public interface IRowDAL
    {
        public IList<ArticleDto> GetAll();

        public bool AddRow(RowDto rowDto);

        public bool UpdateArticle(RowDto rowDto);

        public bool DeleteArticle(RowDto rowDto);
    }
}