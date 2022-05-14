using AxiLogic.Factories;
using AxiLogic.Helpers;

namespace Axi3._0.Models
{
    public class MoveArticleViewModel
    {
       public int articleID { get; set; }
       public string locationstring { get; set; }
       
       public string PalletLocation { get; set; }
       
       public string PlankLocation { get; set; }
       
       public string RackLocation { get; set; }
       
       public string RowName { get; set; }
       public int amount { get; set; }

        public void PlaceArticle()
        {
            MoveArticleViewModelHelper moveTakeArticleViewModelHelper = ContainerFactory.MoveArticleViewModelHelper;
            moveTakeArticleViewModelHelper.PlaceArticle(articleID, locationstring, amount);        
        }

        public void TakeArticle()
        {
            MoveArticleViewModelHelper moveTakeArticleViewModelHelper = ContainerFactory.MoveArticleViewModelHelper;
            moveTakeArticleViewModelHelper.TakeArticle(articleID, locationstring, amount);
        }
    }
}
