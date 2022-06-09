using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class ShipmentMock : IShipmentDAL // to do
    {
        private IDalFactory _mockFactory;
        public List<ShipmentDto> ShipmentDtos = new();

        public ShipmentMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;

            var shipment1 = new ShipmentDto()
            {
                Date = new DateTime(2001, 1, 1),
                Id = 1,
                InvoiceId = 1,
                Name = "Name1",
                Processed = true,
                // ShipmentArticles = 
            };

            var shipment2 = new ShipmentDto()
            {
                Date = new DateTime(2002, 2, 2),
                Id = 2,
                InvoiceId = 2,
                Name = "Name2",
                Processed = true,
            };
            ShipmentDtos.Add(shipment1);
            ShipmentDtos.Add(shipment2);
        }
        
        
        public IList<ShipmentDto> GetAll()
        {
            return ShipmentDtos;
        }       

        public int AddShipment(ShipmentDto shipmentDto)
        {
            ShipmentDtos.Add(shipmentDto);
            var index = ShipmentDtos.Count - 1;
            return index;
        }

        public void RemoveShipment(ShipmentDto shipmentDto)
        {
            ShipmentDtos.Remove(shipmentDto);
        }

        public void UpdateShipment(ShipmentDto shipmentDto)
        {
            foreach (var dto in ShipmentDtos)
            {
                if (dto.Id == shipmentDto.Id)
                {
                    ShipmentDtos.Remove(dto);
                    ShipmentDtos.Add(shipmentDto);
                }
            }
        }

        public IList<ShipmentDto> GetAllUnfinishedShipments()
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