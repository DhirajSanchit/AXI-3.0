using System.Collections.Generic;
using AxiLogic.Classes;

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
            //keeps track of id's of articles that have been added to stock rows
            var addedArticles = new List<int>();
            foreach (var row in ContainerFactory.RowContainer.Rows)
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
            // adds row name to the location name
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
            //adds rack location to the location name
            var rackLocation = $"{rowLocation}.{rack.Location}";
            foreach (var plank in rack.Planks)
            {
                LoopPallets(addedArticles, stockRows, rackLocation, plank);
            }
        }

        private void LoopPallets(List<int> addedArticles, List<StockRow> stockRows, string rackLocation, Plank plank)
        {
            //adds plank location to the location name
            var plankLocation = $"{rackLocation}.{plank.Location}";
            foreach (var pallet in plank.GetPallets())
            {
                ModifyStockRows(addedArticles, pallet, stockRows, plankLocation);
            }
        }

        /// <summary>
        /// Adds a new stock row for new articles. If the article is already contained it modifies the existing stock row.
        /// </summary>
        private void ModifyStockRows(List<int> addedArticles, Pallet pallet, List<StockRow> stockRows, string plankLocation)
        {
            //checks if there is an article to be added to the stock index
            if (pallet.Article != null)
            {
                //checks if the article has been indexed through another location
                if (addedArticles.Contains(pallet.Article.Id))
                {
                    //adds the amount and current location to total of the article in the index
                    ModifyArticleStockRow(stockRows, pallet.Article.Id, $"{plankLocation}.{pallet.Location}",
                        pallet.Amount);
                }
                else
                {
                    //creates a new row for the not yet indexed article to be indexed
                    stockRows.Add(new StockRow()
                    {
                        ArticleId = pallet.Article.Id,
                        ArticleName = pallet.Article.Name,
                        Category = pallet.Article.Category,
                        Locations = new List<string>() {$"{plankLocation}.{pallet.Location}"},
                        Quantity = pallet.Amount
                    });
                    //adds the id to added articles to keep track of already indexed articles
                    addedArticles.Add(pallet.Article.Id);
                }
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