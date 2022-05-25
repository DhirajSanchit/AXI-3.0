using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class ShipmentMock : IShipmentDAL
    {
        private IDalFactory _mockFactory;
        public List<ShipmentDto> ShipmentDtos = new();

        public ShipmentMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
            
            ShipmentDtos.Add(new ShipmentDto()
            {
                Date = new DateTime(2001, 1, 1),
                Id = 1,
                InvoiceId = 1,
                Name = "Name1",
                Processed = true,
                // ShipmentArticles = 
            });
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