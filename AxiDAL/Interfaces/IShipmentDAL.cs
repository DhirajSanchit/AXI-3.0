using AxiDAL.DTOs;
using System.Collections.Generic;

namespace AxiDAL.Interfaces
{
    public interface IShipmentDAL
    {
        public IList<ShipmentDto> GetAll();
        public IList<ShipmentDto> GetAllUnfinishedShipments();
        public int AddShipment(ShipmentDto shipmentDto);
        public void RemoveShipment(ShipmentDto shipmentDto);
        public void UpdateShipment(ShipmentDto shipmentDto);
        public ShipmentDto GetShipmentById(int id);
        public void UpdateShipmentProgress(ShipmentDto shipmentDto);
    }
}