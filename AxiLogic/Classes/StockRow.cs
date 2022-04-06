using System.Collections.Generic;
using AxiLogic.Helpers;
namespace AxiLogic.Classes
{
    public class StockRow
    {
        public string ArticleName;
        public int ArticleId;
        public int Quantity;
        public Category Category;
        public List<string> Locations;

    }
}