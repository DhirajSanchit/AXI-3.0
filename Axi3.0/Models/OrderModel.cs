using System;
using System.Collections.Generic;
using AxiLogic.Classes;

namespace Axi3._0.Models
{
    public class OrderModel
    {
        public DateTime Date { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public bool Processed { get; set; }

        public List<OrderArticle> _orderArticles { get; set; }
    }
}