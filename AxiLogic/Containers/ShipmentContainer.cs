using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{
    public class ShipmentContainer
    {
        private List<Shipment> _shipments;
        private IShipmentDAL dal;
        
        public IReadOnlyCollection<Shipment> GetShipment()
        {
            return _shipments;
        }

        public ShipmentContainer(IShipmentDAL iShipmentDAL)
        {
            dal = iShipmentDAL;
        }

        public void ClearShipments()
        {
            _shipments.Clear();
        }


        /// <summary>
        /// Loads shipments that need to be processed from DB.
        /// </summary>
        public List<ShipmentDto> GetProcessableShipments()
        {
            var ShipmentDtos = dal.GetAllUnfinishedShipments();
            List<ShipmentDto> shipments = new();
            foreach (var shipmentDto in ShipmentDtos)
            {
                shipments.Add(shipmentDto);
            }

            return shipments;
        }
        
        /// <summary>
        /// Loads all shipments from DB.
        /// </summary>
        public void LoadAllShipments()
        {
            //TODO get data from DB
            //TODO make async?
        }
        
        public void AddShipment(Shipment shipment)
        {
            if (_shipments.Contains(shipment))
            {
                throw new ArgumentException("Can not add duplicate shipment to list");
            }
            _shipments.Add(shipment);
        }

        public void RemoveShipment(Shipment shipment)
        {
            if (!_shipments.Contains(shipment))
            {
                throw new ArgumentException("Can not remove non-contained shipment from list");
            }
            _shipments.Remove(shipment);
        }
    }
}