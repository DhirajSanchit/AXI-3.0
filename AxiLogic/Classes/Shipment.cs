using System;
using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiLogic.Classes
{
    public class Shipment
    {
        public DateTime Date { get; private set; }
        public int InvoiceId { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }
        
        private List<ShipmentArticle> _shipmentArticles = new();
        
        
        public Shipment(int id)
        {
            Id = id;
        }
        
        public Shipment(ShipmentDto shipmentDto)
        {
            Date = shipmentDto.Date;
            InvoiceId = shipmentDto.InvoiceId;
            Name = shipmentDto.Name;
            Id = shipmentDto.Id;
            //Add list :-)
        }
        public void ClearShipmentArticles()
        {
            _shipmentArticles.Clear();
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
            return _shipmentArticles;
        }

        public void AddShipmentArticle(ShipmentArticle shipmentArticle)
        {
            _shipmentArticles.Add(shipmentArticle);
        }

        public void RemoveShipmentArticle(ShipmentArticle shipmentArticle)
        {
            _shipmentArticles.Remove(shipmentArticle);
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