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
            return new ArticleMock(this);
        }

        public ITestDAL GetTestDal()
        {
            throw new NotImplementedException();
        }

        public IShipmentDAL GetShipmentDal()
        {
            return new ShipmentMock(this);
        }

        public IShipmentArticleDAL GetShipmentArticleDAL()
        {
            return new ShipmentArticleMock(this);
        }

        public IRowDAL GetRowDal()
        {
            return new RowMock(this);
        }

        public IOrderArticleDAL GetOrderArticleDal()
        {
            return new OrderArticleMock(this);
        }

        public IOrderDAL GetOrderDal()
        {
            return new OrderMock(this);
        }
        
        public ICategoryDAL GetCategoryDal()
        {
            return new CategoryMock(this);
        }
    }
}