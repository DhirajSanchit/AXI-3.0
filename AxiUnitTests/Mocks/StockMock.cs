using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiUnitTests.Mocks
{
    public class StockMock : IStockDAL
    {
        public List<StockDto> stocks = new List<StockDto>();

        public IList<StockDto> GetAll()
        {
            return stocks;
        }
    }
}
