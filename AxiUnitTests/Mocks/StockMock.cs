using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiUnitTests.Mocks
{
    public class StockMock : IStockDAL // CONSTRUCTOR NEPDATA
    {
        private IDalFactory mockdalfactory;
        public List<StockDto> stocks = new List<StockDto>();

        public StockMock(IDalFactory dalFactory)
        {
            mockdalfactory = dalFactory;
            var stock1 = new StockDto()
            {
                Amount = 2,
                Id = 1,
                Name = "Name1",
            };
            var stock2 = new StockDto()
            {
                Amount = 12,
                Id = 2,
                Name = "Name2",
            };
        }

        public IList<StockDto> GetAll()
        {
            return stocks;
        }
    }
}
