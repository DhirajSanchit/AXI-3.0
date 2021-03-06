using System;
using AxiDAL.DAL;
using AxiDAL.Interfaces;
using AxiUnitTests.Mocks;
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
        public PlankMock PlankMock { get; set; }
        public PalletMock PalletMock { get; set; }

        
        public MockFactory()
        {
            ArticleMock = new ArticleMock(this);
            ShipmentMock = new ShipmentMock(this);
            ShipmentArticleMock = new ShipmentArticleMock(this);
            RowMock = new RowMock(this);
            OrderArticleMock = new OrderArticleMock(this);
            OrderMock = new OrderMock(this);
            CategoryMock = new CategoryMock(this);
            PlankMock = new PlankMock(this);
            PalletMock = new PalletMock(this);
        }
        
        public IArticleDAL GetArticleDal()
        {
            return ArticleMock;
        }

        public ITestDAL GetTestDal()
        {
            throw new NotImplementedException();
        }

        public IStockDAL GetStockDAL()
        {
            throw new NotImplementedException();
        }

        public IStatisticsDAL GetStatisticsDal()
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

        public IPlankDAL GetPlankDAL()
        {
            return PlankMock;
        }
        public IPalletDAL GetPalletDAL()
        {
            return PalletMock;
        }
    }
}