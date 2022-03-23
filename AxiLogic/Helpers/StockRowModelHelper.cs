using System.Collections.Generic;
using Axi3._0;
using AxiLogic.Classes;
using AxiLogic.Containers;

namespace AxiLogic.Helpers
{
    public class StockRowModelHelper
    {
        /// <summary>
        /// Returns a row for any type of article within the stock.
        /// </summary>
        public List<StockRow> GetStockRows()
        {
            var stockRows = new List<StockRow>();
            var addedArticles = new List<int>();
            foreach (var row in Toolbox.RowContainer.Rows)
            {
                LoopRacks(row, addedArticles, stockRows);
            }
            return stockRows;
        }

        /// <summary>
        /// Loops through all racks in a row with the row's name.
        /// </summary>
        private void LoopRacks(Row row, List<int> addedArticles, List<StockRow> stockRows)
        {
            var rowLocation = row.Name;
            foreach (var rack in row.Racks)
            {
                LoopPlanks(rowLocation, rack, addedArticles, stockRows);
            }
        }

        /// <summary>
        /// Loops through all planks in a rack with the rack's location string.
        /// </summary>
        private void LoopPlanks(string rowLocation, Rack rack, List<int> addedArticles, List<StockRow> stockRows)
        {
            var rackLocation = $"{rowLocation}.{rack.Location}";
            foreach (var plank in rack.Planks)
            {
                var plankLocation = $"{rackLocation}.{plank.Location}";
                foreach (var pallet in plank.GetPallets())
                {
                    ModifyStockRows(addedArticles, pallet, stockRows, plankLocation);
                }
            }
        }

        /// <summary>
        /// Adds a new stock row for new articles. If the article is already contained it modifies the existing stock row.
        /// </summary>
        private void ModifyStockRows(List<int> addedArticles, Pallet pallet, List<StockRow> stockRows, string plankLocation)
        {
            if (addedArticles.Contains(pallet.Article.Id))
            {
                ModifyArticleStockRow(stockRows, pallet.Article.Id, $"{plankLocation}.{pallet.Location}", pallet.Amount);
            }
            else
            {
                stockRows.Add(new StockRow()
                {
                    ArticleId = pallet.Article.Id,
                    ArticleName = pallet.Article.Name,
                    Category = pallet.Article.Category,
                    Locations = new List<string>() {$"{plankLocation}.{pallet.Location}"},
                    Quantity = pallet.Amount
                });
            }
        }
        
        /// <summary>
        /// Modifies an existing stock row to add the new location and amount.
        /// </summary>
        private void ModifyArticleStockRow(List<StockRow> stockRows, int articleId, string location, int amount)
        {
            foreach (var stockRow in stockRows)
            {
                if (stockRow.ArticleId == articleId)
                {
                    stockRow.Quantity += amount;
                    stockRow.Locations.Add(location);
                }  
            }
        }
    }
}