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
            //todo get data from DB
            //todo make async?
        }
        
        public void CreateShipment(string name, DateTime date, int invoiceId, List<ShipmentArticle> shipmentArticles)
        {
            //todo add Shipment to database with the given parameters
            var id = 0; //todo replace this placeholder with id from database response
            var shipment = new Shipment(id);
            shipment.SetName(name);
            shipment.SetDate(date);
            shipment.SetInvoiceId(invoiceId);
            foreach (var shipmentArticle in shipmentArticles)
            {
                shipment.AddShipmentArticle(shipmentArticle);
            }
            _shipments.Add(shipment);
        }

        public void RemoveShipment(Shipment shipment)
        {
            _shipments.Remove(shipment);
        }
    }
}