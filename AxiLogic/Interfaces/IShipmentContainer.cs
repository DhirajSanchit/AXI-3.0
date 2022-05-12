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
        public void LoadAllShipments();
        public void AddShipment(Shipment shipment);
        public void RemoveShipment(Shipment shipment);
    }
}