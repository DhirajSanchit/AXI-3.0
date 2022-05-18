using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class ShipmentMock : IShipmentDAL
    {
        private IDalFactory _mockFactory;
        
        public ShipmentMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
        }
        
        
        public IList<ShipmentDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IList<ShipmentDto> GetAllUnfinishedShipments()
        {
            throw new System.NotImplementedException();
        }

        public int AddShipment(ShipmentDto shipmentDto)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveShipment(ShipmentDto shipmentDto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateShipment(ShipmentDto shipmentDto)
        {
            throw new System.NotImplementedException();
        }

        public ShipmentDto GetShipmentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateShipmentProgress(ShipmentDto shipmentDto)
        {
            throw new System.NotImplementedException();
        }
    }
}