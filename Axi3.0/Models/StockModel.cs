using System.Collections.Generic;
using AxiLogic.Classes;
using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class StockModel
    {
        public List<StockRowModel> StockRows = new();

        
        
        public void GetStockRows()
        {
            StockRows.Clear();
            var stockRows = ContainerFactory.StockRowModelHelper.GetStockRows();
            foreach (var row in stockRows)
            {
                StockRows.Add(new StockRowModel()
                {
                    ArticleName = row.ArticleName,
                    ArticleId = row.ArticleId,
                    Category = row.Category,
                    Locations = row.Locations,
                    Quantity = row.Quantity
                });
            }
        }
    }
}