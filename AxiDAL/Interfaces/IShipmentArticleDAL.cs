using AxiDAL.DTOs;
using System.Collections.Generic;

namespace AxiDAL.Interfaces
{
    public interface IShipmentArticleDAL
    {
        public IList<ShipmentArticleDto> GetAllShipmentArticlesFromShipment(ShipmentDto shipment);
        public int AddShipmentArticle(ShipmentArticleDto shipmentArticle);
        public void UpdateShipmentArticle(ShipmentArticleDto shipmentArticle);
        public void DeleteShipmentArticle(ShipmentArticleDto shipmentArticle);

    }
}