using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiLogic.Classes;

namespace AxiLogic.Interfaces
{
    public interface IShipmentContainer
    {
        public IReadOnlyCollection<Shipment> GetShipment();
        public void ClearShipments();
        public List<ShipmentDto> GetProcessableShipments();
        public IList<ShipmentDto> GetAllUnfinishedShipments();
        public void AddShipment(Shipment shipment);
        public void RemoveShipment(Shipment shipment);
        public IList<ShipmentArticleDto> getShipmentArticles(int shipmentId);
        public ShipmentDto GetShipmentById(int shipmentId);
        public void UpdateShipment(ShipmentDto shipmentDto);
    }
}