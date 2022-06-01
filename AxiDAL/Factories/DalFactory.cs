using System;
using AxiDAL.DAL;
using AxiDAL.Interfaces;

namespace AxiDAL.Factories
{
    public class DalFactory : IDalFactory
    {
        private IServiceProvider serviceProvider;

        
        public DalFactory(IServiceProvider ServiceProvider)
        {
            serviceProvider = ServiceProvider;
        }

        public ITestDAL GetTestDal()
        {
            return (ITestDAL)serviceProvider.GetService(typeof(TestDAL));
        }

        public IArticleDAL GetArticleDal()
        {
            return (IArticleDAL)serviceProvider.GetService(typeof(ArticleDAL));
        }
        
        public IShipmentDAL GetShipmentDal()
        {
            return (IShipmentDAL)serviceProvider.GetService(typeof(ShipmentDAL));
        }

        public IShipmentArticleDAL GetShipmentArticleDAL()
        {
            return (IShipmentArticleDAL)serviceProvider.GetService(typeof(ShipmentArticleDAL));
        }
        public IRowDAL GetRowDal()
        {
            return (IRowDAL)serviceProvider.GetService(typeof(RowDAL));
        }
        
        public IOrderArticleDAL GetOrderArticleDal()
        {
            return (IOrderArticleDAL)serviceProvider.GetService(typeof(IOrderArticleDAL));
        }
        
        public IOrderDAL GetOrderDal()
        {
            return (IOrderDAL)serviceProvider.GetService(typeof(IOrderDAL));
        }
        
        
        //TODO: Revise with cleaner code
        public ICategoryDAL GetCategoryDal()
        {
            return (ICategoryDAL)serviceProvider.GetService(typeof(CategoryDAL));
        }

        public IStockDAL GetStockDAL()
        {
            return (IStockDAL)serviceProvider.GetService(typeof(StockDAL));
        }
    }
}

 