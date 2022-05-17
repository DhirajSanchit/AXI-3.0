using System;
using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class Order
    {
        public DateTime Date { get; private set; }
        public int InvoiceId { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }
        
        public bool Processed { get; private set; }
        
        private List<OrderArticle> _orderArticles = new();
        
        
        public Order(int id)
        {
            Id = id;
        }
        
        public Order(OrderDto orderDto)
        {
            Date = orderDto.Date;
            InvoiceId = orderDto.InvoiceId;
            Name = orderDto.Name;
            Id = orderDto.Id;
            Processed = orderDto.Processed;
            //Add list :-)
        }
        public void ClearOrderArticles()
        {
            _orderArticles.Clear();
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

        public IReadOnlyList<OrderArticle> GetOrderArticles()
        {
            return _orderArticles;
        }

        public void AddOrderArticle(OrderArticle orderArticle)
        {
            _orderArticles.Add(orderArticle);
        }

        public void RemoveOrderArticle(OrderArticle orderArticle)
        {
            _orderArticles.Remove(orderArticle);
        }

        public OrderDto ToDto()
        {
            return new OrderDto
            {
                Date = Date,
                InvoiceId = InvoiceId,
                Name = Name,
                Id = Id,
                Processed = Processed
            };
        }
    }
}