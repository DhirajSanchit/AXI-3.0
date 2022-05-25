using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Factories;
using AxiLogic.Helpers;
using AxiLogic.Interfaces;

namespace AxiLogic.Helpers
{
    public class MoveArticleViewModelHelper
    {
        private ContainerFactory _containerFactory;
        
        public MoveArticleViewModelHelper(ContainerFactory containerFactory)
        {
            _containerFactory = containerFactory;
        }
        
        public void PlaceArticle(int articleID, string locationstring, int amount)
        {
            var locations = locationstring.Split(".");

            var articleContainer = _containerFactory.GetArticleContainer();
            articleContainer.GetAllArticles();
            var article = new Article(articleContainer.GetArticleById(articleID));
            var rowContainer = _containerFactory.GetRowContainer();
            var row = rowContainer.GetRowByName(locations[0]);
            var rack = row.GetRack(Convert.ToInt32(locations[1]));
            var plank = rack.GetPlankByLocation(Convert.ToInt32(locations[2]));
            var pallet = plank.GetPallet(Convert.ToInt32(locations[3]));
            pallet.PlaceArticle(article, amount);
            
        }

        public void TakeArticle(int articleID, string locationstring, int amount)
        {
            //to do: write test
            var locations = locationstring.Split('.');

            var articleContainer = _containerFactory.GetArticleContainer();
            articleContainer.GetAllArticles();
            var article = new Article(articleContainer.GetArticleById(articleID));
            var rowContainer = _containerFactory.GetRowContainer();
            var row = rowContainer.GetRowByName(locations[0]);
            var rack = row.GetRack(Convert.ToInt32(locations[1]));
            var plank = rack.GetPlankByLocation(Convert.ToInt32(locations[2]));
            var pallet = plank.GetPallet(Convert.ToInt32(locations[3]));
            pallet.RemoveArticle(article, amount);
        }
    }
}
