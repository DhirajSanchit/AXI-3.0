using System.Collections.Generic;
using AxiLogic.Classes;

namespace Axi3._0.Models
{
    public class StockRowModel
    {
        public string ArticleName;
        public int ArticleId;
        public int Quantity;
        public string Category;
        public List<string> Locations;
    }
}