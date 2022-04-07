using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class MoveArticleViewModel
    {
       public int articleID { get; set; }
       public string locationstring { get; set; }
       public int amount { get; set; }

        public void PlaceArticle()
        {
            MoveArticleViewModelHelper moveTakeArticleViewModelHelper = Toolbox.PlaceTakeArticleViewModelHelper;
            moveTakeArticleViewModelHelper.PlaceArticle(articleID, locationstring, amount);        
        }

        public void TakeArticle()
        {
            MoveArticleViewModelHelper moveTakeArticleViewModelHelper = Toolbox.PlaceTakeArticleViewModelHelper;
            moveTakeArticleViewModelHelper.TakeArticle(articleID, locationstring, amount);
        }
    }
}
