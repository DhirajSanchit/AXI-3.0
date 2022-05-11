using AxiDAL.DTOs;
using System.Collections.Generic;

namespace AxiDAL.Interfaces
{
    public interface IRowDAL
    {
        public IList<RowDto> GetAll();

        public int AddRow(RowDto rowDto);

        public void UpdateArticle(RowDto rowDto);

        public void DeleteArticle(RowDto rowDto);
    }
}