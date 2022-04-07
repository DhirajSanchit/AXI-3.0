using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Helpers;

namespace AxiLogic.Helpers
{
    public class MoveArticleViewModelHelper
    {
        public void PlaceArticle(int articleID, string locationstring, int amount)
        {
            string[] locations = locationstring.Split(".");

            ArticleContainer articleContainer = Toolbox.ArticleContainer;
            Article article = articleContainer.GetArticleByID(articleID);
            RowContainer rowContainer = Toolbox.RowContainer;
            Row row = rowContainer.GetRowByName(locations[0]);
            Rack rack = row.GetRack(Convert.ToInt32(locations[1]));
            Plank plank = rack.GetPlankByLocation(Convert.ToInt32(locations[2]));
            Pallet pallet = plank.GetPallet(Convert.ToInt32(locations[3]));
            pallet.PlaceArticle(article, amount);
        }

        public void TakeArticle(int articleID, string locationstring, int amount)
        {
            //to do: write test
            string[] locations = locationstring.Split('.');

            ArticleContainer articleContainer = Toolbox.ArticleContainer;
            Article article = articleContainer.GetArticleByID(articleID);
            RowContainer rowContainer = Toolbox.RowContainer;
            Row row = rowContainer.GetRowByName(locations[0]);
            Rack rack = row.GetRack(Convert.ToInt32(locations[1]));
            Plank plank = rack.GetPlankByLocation(Convert.ToInt32(locations[2]));
            Pallet pallet = plank.GetPallet(Convert.ToInt32(locations[3]));
            pallet.RemoveArticle(article, amount);
        }
    }
}
