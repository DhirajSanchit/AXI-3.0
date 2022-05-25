using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class ShipmentArticleMock : IShipmentArticleDAL
    {
        private IDalFactory _mockFactory;
        
        public ShipmentArticleMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
            
        }
        
        public IList<ShipmentArticleDto> GetAllShipmentArticlesFromShipment(ShipmentDto shipment)
        {
            throw new System.NotImplementedException();
        }

        public int AddShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateShipmentArticleProgress(ShipmentArticleDto shipmentArticleDto)
        {
            throw new System.NotImplementedException();
        }
    }
}