using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Classes;
using AxiLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiLogic.Containers
{
    public class StockContainer : IStockContainer
    {
        private IList<Stock> _stocks;
        private IDalFactory _idalFactory;
        public StockContainer(DalFactory idalFactory)
        {
            _idalFactory = idalFactory;
        }
        
        public IList<Stock> GetStocks()
        {

            return _stocks;
        }

        public IList<Stock> GetAllStocks()
        {
            var stockDtos = _idalFactory.GetStockDAL().GetAll();
            List<Stock> stocks = new();
            foreach (var stockDTO in stockDtos)
            {
                stocks.Add(new Stock(stockDTO));
            }

            return _stocks = stocks;
        }

    }
}
