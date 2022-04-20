using System;
using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{
    public class ShipmentContainer
    {
        private List<Shipment> _shipments = new();

        public IReadOnlyCollection<Shipment> GetShipments()
        {
            return _shipments;
        }

        public Shipment GetShipment(int index)
        {
            return _shipments[index];
        }

        public void ClearShipments()
        {
            _shipments.Clear();
        }
        
        
        /// <summary>
        /// Loads shipments that need to be processed from DB.
        /// </summary>
        public void LoadProcessableShipments()
        {
            //todo get data from DB
            //todo make async?
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