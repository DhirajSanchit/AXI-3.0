using AxiInterfaces.DTOs;
using System;
using System.Collections.Generic;

namespace AxiLogic.Classes
{
    public class Shipment
    {
        public DateTime Date { get; private set; }
        public int InvoiceId { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }
        
        private List<ShipmentArticle> ShipmentArticles = new();
        
        
        public Shipment(int id)
        {
            Id = id;
        }

        public void ClearShipmentArticles()
        {
            ShipmentArticles.Clear();
        }
        
        public void SetDate(DateTime date)
        {
            Date = date;
        }

        public void SetInvoiceId(int invoiceId)
        {
            InvoiceId = invoiceId;
        }
        
        public void SetName(string name)
        {
            Name = name;
        }

        public IReadOnlyList<ShipmentArticle> GetShipmentArticles()
        {
            return ShipmentArticles;
        }

        public void AddShipmentArticle(ShipmentArticle shipmentArticle)
        {
            ShipmentArticles.Add(shipmentArticle);
        }

        public void RemoveShipmentArticle(ShipmentArticle shipmentArticle)
        {
            ShipmentArticles.Remove(shipmentArticle);
        }

        public ShipmentDto ToDto()
        {
            return new ShipmentDto
            {
                Date = Date,
                InvoiceId = InvoiceId,
                Name = Name,
                Id = Id
            };
        }
    }
}