using System.Collections.Generic;
using AxiLogic.Classes;
using AxiLogic.Factories;

namespace AxiLogic.Helpers
{
    public class StockRowModelHelper
    {
        private ContainerFactory _containerFactory;
        
        public StockRowModelHelper(ContainerFactory containerFactory)
        {
            _containerFactory = containerFactory;
        }


        /// <summary>
        /// Returns a row for any type of article within the stock.
        /// </summary>
        public List<StockRow> GetStockRows()
        {
            var stockRows = new List<StockRow>();
            //keeps track of id's of articles that have been added to stock rows
            var addedArticles = new List<int>();
            foreach (var row in _containerFactory.GetRowContainer().GetRows())
            {
                LoopRacks(row, stockRows);
            }
            return stockRows;
        }

        /// <summary>
        /// Loops through all racks in a row with the row's name.
        /// </summary>
        private void LoopRacks(Row row, List<StockRow> stockRows)
        {
            // adds row name to the location name
            var rowLocation = row.Name;
            foreach (var rack in row.Racks)
            {
                LoopPlanks(rowLocation, rack, stockRows);
            }
        }

        /// <summary>
        /// Loops through all planks in a rack with the rack's location string.
        /// </summary>
        private void LoopPlanks(string rowLocation, Rack rack, List<StockRow> stockRows)
        {
            //adds rack location to the location name
            var rackLocation = $"{rowLocation}.{rack.Location}";
            foreach (var plank in rack.Planks)
            {
                LoopPallets(stockRows, rackLocation, plank);
            }
        }

        private void LoopPallets(List<StockRow> stockRows, string rackLocation, Plank plank)
        {
            //adds plank location to the location name
            var plankLocation = $"{rackLocation}.{plank.Location}";
            foreach (var pallet in plank.GetPallets())
            {
                ModifyStockRows(pallet, stockRows, plankLocation);
            }
        }

        /// <summary>
        /// Adds a new stock row for new articles. If the article is already contained it modifies the existing stock row.
        /// </summary>
        private void ModifyStockRows( Pallet pallet, List<StockRow> stockRows, string plankLocation)
        {
            //checks if there is an article to be added to the stock index
            if (pallet.Article != null)
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
    }
}