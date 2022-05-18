using System;
using AxiDAL.DAL;
using AxiDAL.Interfaces;
using AxiUnitTests.Scrubs;

namespace AxiUnitTests
{
    public class MockFactory : IDalFactory
    {
        
        public IArticleDAL GetArticleDal()
        {
            return new ArticleMock();
        }

        public ITestDAL GetTestDal()
        {
            throw new NotImplementedException();
        }

        public IShipmentDAL GetShipmentDal()
        {
            return new ShipmentMock();
        }

        public IShipmentArticleDAL GetShipmentArticleDAL()
        {
            return new ShipmentArticleMock();
        }

        public IRowDAL GetRowDal()
        {
            return new RowMock();
        }

        public IOrderArticleDAL GetOrderArticleDal()
        {
            return new OrderArticleMock();
        }

        public IOrderDAL GetOrderDal()
        {
            return new OrderMock();
        }
        
        public ICategoryDAL GetCategoryDal()
        {
            return new CategoryMock();
        }
    }
}