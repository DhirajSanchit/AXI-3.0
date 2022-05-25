using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class ShipmentArticleMock : IShipmentArticleDAL
    {
        private IDalFactory _mockFactory;
        public List<ShipmentArticleDto> ShipmentArticleDtos = new();

        public ShipmentArticleMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
            
            ShipmentArticleDtos.Add(new ShipmentArticleDto()
            {
                Amount = 1,
                Article = _mockFactory.GetArticleDal().GetAll()[0],
                ArticleId = 1,
                ScannedAmount = 1,
                ShipmentId = 1
            });
            ShipmentArticleDtos.Add(new ShipmentArticleDto()
            {
                Amount = 2,
                Article = _mockFactory.GetArticleDal().GetAll()[1],
                ArticleId = 2,
                ScannedAmount = 2,
                ShipmentId = 2
            });
        }
        
        public IList<ShipmentArticleDto> GetAllShipmentArticlesFromShipment(ShipmentDto shipment)
        {
            List<ShipmentArticleDto> returnList = new();
            foreach (var dto in ShipmentArticleDtos)
            {
                if (dto.ShipmentId == shipment.Id)
                {
                    returnList.Add(dto);
                }
            }

            return returnList;
        }

        public int AddShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            ShipmentArticleDtos.Add(shipmentArticle);
            return shipmentArticle.ArticleId; //todo void this?
        }

        public void UpdateShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            var thisDto = new ShipmentArticleDto();
            foreach (var dto in ShipmentArticleDtos)
            {
                if (dto.ArticleId == shipmentArticle.ArticleId && dto.ShipmentId == shipmentArticle.ShipmentId)
                {
                    thisDto = dto;
                    ShipmentArticleDtos.Remove(dto);
                }
            }
            ShipmentArticleDtos.Add(thisDto);
        }

        public void DeleteShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            ShipmentArticleDtos.Remove(shipmentArticle);
        }

        public void UpdateShipmentArticleProgress(ShipmentArticleDto shipmentArticleDto)
        {
            throw new System.NotImplementedException(); //todo this
        }
    }
}