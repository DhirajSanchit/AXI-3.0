using System;
using AxiDAL.DAL;
using AxiDAL.Interfaces;
using AxiUnitTests.Scrubs;

namespace AxiUnitTests
{
    public class MockFactory : IDalFactory
    {
        public ArticleMock ArticleMock { get; set; }
        public ShipmentMock ShipmentMock { get; set; }
        public ShipmentArticleMock ShipmentArticleMock { get; set; }
        public RowMock RowMock { get; set; }
        public OrderArticleMock OrderArticleMock { get; set; }
        public OrderMock OrderMock { get; set; }
        public CategoryMock CategoryMock { get; set; }
        
        public MockFactory()
        {
            
        }
        
        public IArticleDAL GetArticleDal()
        {
            return ArticleMock;
        }

        public ITestDAL GetTestDal()
        {
            throw new NotImplementedException();
        }

        public IShipmentDAL GetShipmentDal()
        {
            return ShipmentMock;
        }

        public IShipmentArticleDAL GetShipmentArticleDAL()
        {
            return ShipmentArticleMock;
        }

        public IRowDAL GetRowDal()
        {
            return RowMock;
        }

        public IOrderArticleDAL GetOrderArticleDal()
        {
            return OrderArticleMock;
        }

        public IOrderDAL GetOrderDal()
        {
            return OrderMock;
        }
        
        public ICategoryDAL GetCategoryDal()
        {
            return CategoryMock;
        }
    }
}