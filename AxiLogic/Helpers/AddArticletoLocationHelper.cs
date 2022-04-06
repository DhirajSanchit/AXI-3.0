using AxiLogic.Classes;
using AxiLogic.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiLogic.Helpers
{
   public class AddArticletoLocationHelper
   {
        public void AddArticletoLocation(Article article, string locationstring, int amount)
        {
            string[] locations = locationstring.Split(".");

            RowContainer rowContainer = Toolbox.RowContainer;
            Row row = rowContainer.GetRowByName(locations[0]);
            Rack rack = row.GetRack(locationstring[1]);
            Plank plank = rack.GetPlankByLocation(locationstring[2]);
            Pallet pallet = plank.GetPallet(locationstring[3]);
            pallet.PlaceArticle(article, amount);

        }
   }
}
