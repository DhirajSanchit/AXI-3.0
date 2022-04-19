
using AxiDAL.DAL;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Interfaces;

namespace AxiLogic.Helpers
{
    public class Toolbox
    {
        public static ShipmentContainer ShipmentContainer = new();
        public static ArticleContainer ArticleContainer = new();
        public static RowContainer RowContainer = new();
        public static StockRowModelHelper StockRowModelHelper = new ();

        public static IArticleContainer iac;
        public static MoveArticleViewModelHelper PlaceTakeArticleViewModelHelper = new();

        public ITestDapperContainer CreateItdc()
        {
            //return new TestDapperContainer();
            return null;
            
        }
         
        
        
        
        // public static IArticleContainer Build()
        // {
        //   return new ArticleContainer();   
        // }


        // public static ITestDapperContainer CreateContainer()
        // {
        //     return new TestDapperContainer();
        //     return null;
        // }
        
        
        
        
        //TODO: ADD DATA
        // //public static DataBaseClient DataBaseClient = new();
        // public static RackDAL RackDal = new();
        // public static RowDAL RowDal = new();
        // public static PalletDAL PalletDal = new();
        // public static PlankDAL PlankDal = new();
        // public static ArticleDAL ArticleDal = new();
        // public static EmployeeDAL EmployeeDal = new();
        // public static ShipmentDAL ShipmentDal = new();
        // public static ShipmentArticleDAL ShipmentArticleDal = new();
        
        
    }
}