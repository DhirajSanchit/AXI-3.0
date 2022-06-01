using System;
using AxiLogic.Containers;
using AxiLogic.Helpers;
using AxiLogic.Interfaces;

namespace AxiLogic.Factories
{
    public class ContainerFactory
    {
        
        private readonly IServiceProvider _serviceProvider;

        public static StockRowModelHelper StockRowModelHelper;
        public static MoveArticleViewModelHelper MoveArticleViewModelHelper;

        public ContainerFactory(IServiceProvider ServiceProvider)
        {
            _serviceProvider = ServiceProvider;
            StockRowModelHelper = new StockRowModelHelper(this);
            MoveArticleViewModelHelper = new MoveArticleViewModelHelper(this);
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

        public IShipmentContainer GetShipmentContainer()
        {
            return (IShipmentContainer)_serviceProvider.GetService(typeof(ShipmentContainer));
        }

        public IOrderContainer GetOrderContainer()
        {
            return (IOrderContainer) _serviceProvider.GetService(typeof(OrderContainer));
        }

        public IRowContainer GetRowContainer()
        {
            return (IRowContainer)_serviceProvider.GetService(typeof(RowContainer));
        }

        public ICategoryContainer GetCategoryContainer()
        {
            return (ICategoryContainer)_serviceProvider.GetService(typeof(CategoryContainer));
        }
        
        public IStockContainer GetStockContainer()
        {
            return (IStockContainer)_serviceProvider.GetService(typeof(StockContainer));
        }

        public IStatContainer GetStatContainer()
        {
            return (IStatContainer)_serviceProvider.GetService(typeof(StatContainer));
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