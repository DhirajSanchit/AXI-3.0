using System;
using System.Data;
using System.Data.SqlClient;
using AxiDAL.DAL;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Interfaces;

namespace AxiLogic.Helpers
{
    public class Toolbox
    {
        
        private IServiceProvider serviceProvider;

        
        
        public static ShipmentContainer ShipmentContainer = new(new ShipmentDAL());
        public static ArticleContainer ArticleContainer = new(new ArticleDAL());
        public static RowContainer RowContainer = new(new RowDAL());
        public static StockRowModelHelper StockRowModelHelper = new ();

        public static IArticleContainer iac;
        public static MoveArticleViewModelHelper PlaceTakeArticleViewModelHelper = new();

        public static ITestDapperContainer _tdc;


        public Toolbox(IServiceProvider ServiceProvider)
        {
            serviceProvider = ServiceProvider;
        }

        public ITestDapperContainer GetTestDapperContainer()
        {
            return (ITestDapperContainer)serviceProvider.GetService(typeof(TestDapperContainer));

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