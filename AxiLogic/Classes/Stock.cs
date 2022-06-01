using AxiDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiLogic.Classes
{
    public class Stock
    {
        public string ArticleName;
        public int Quantity;

        public Stock(StockDto stockDto)
        {
            ArticleName = stockDto.Name;
            Quantity = stockDto.Amount;
        }
    }
}
