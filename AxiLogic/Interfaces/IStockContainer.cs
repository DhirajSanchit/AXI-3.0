using AxiLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiLogic.Interfaces
{
    public interface IStockContainer
    {
        public IList<Stock> GetAllStocks();
    }
}
