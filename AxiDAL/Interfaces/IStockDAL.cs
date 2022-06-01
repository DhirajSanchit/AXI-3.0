using AxiDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiDAL.Interfaces
{
    public interface IStockDAL
    {
        public IList<StockDto> GetAll();
    }
}
