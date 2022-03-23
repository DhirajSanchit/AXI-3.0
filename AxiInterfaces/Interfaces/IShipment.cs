using AxiInterfaces.DTOs;

namespace AxiInterfaces.Interfaces
{
    public interface IShipment
    {
        void ClearShipments(ShipmentDto shipmentDto);
        void LoadProcessableShipments(ShipmentDto shipmentDto);
        void LoadAllShipments(ShipmentDto shipmentDto);
        void CreateShipment(ShipmentDto shipmentDto);
        void RemoveShipment(ShipmentDto shipmentDto);
    }
}