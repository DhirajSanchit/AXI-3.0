using System;
using System.Data;
using System.Data.SqlClient;
using AxiDAL.DAL;
using AxiLogic.Classes;
using AxiLogic.Containers;
using AxiLogic.Interfaces;

namespace AxiLogic.Helpers
{
    public class ContainerFactory
    {
        
        private readonly IServiceProvider _serviceProvider;

        public static ShipmentContainer ShipmentContainer = new(new ShipmentDAL()); 
        public static RowContainer RowContainer = new(new RowDAL());
        public static StockRowModelHelper StockRowModelHelper = new ();
        public static MoveArticleViewModelHelper PlaceTakeArticleViewModelHelper = new();

        public ContainerFactory(IServiceProvider ServiceProvider)
        {
            _serviceProvider = ServiceProvider;
        }

        //Method below is only used to return the test container. Used for proof of concept and testing of IoC and DI
        public ITestDapperContainer GetTestDapperContainer()
        {
            return (ITestDapperContainer)_serviceProvider.GetService(typeof(TestDapperContainer));

        }

        public IArticleContainer GetArticleContainer()
        {
            return (IArticleContainer)_serviceProvider.GetService(typeof(ArticleContainer));
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