using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class MoveArticleViewModel
    {      
        public void PlaceArticle(int articleID, string locationstring, int amount)
        {
            MoveArticleViewModelHelper moveTakeArticleViewModelHelper = Toolbox.PlaceTakeArticleViewModelHelper;
            moveTakeArticleViewModelHelper.PlaceArticle(articleID, locationstring, amount);        
        }

        public void TakeArticle(int articleID, string locationstring, int amount)
        {
            MoveArticleViewModelHelper moveTakeArticleViewModelHelper = Toolbox.PlaceTakeArticleViewModelHelper;
            moveTakeArticleViewModelHelper.TakeArticle(articleID, locationstring, amount);
        }
    }
}
