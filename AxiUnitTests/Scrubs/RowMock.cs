using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class RowMock : IRowDAL
    {
        private IDalFactory _mockFactory;
        
        public RowMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
        }
        
        public IList<RowDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public int AddRow(RowDto rowDto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateArticle(RowDto rowDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteArticle(RowDto rowDto)
        {
            throw new System.NotImplementedException();
        }
    }
}