using AxiLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axi3._0.Models
{
    public class ShipmentModel
    {
        public DateTime Date { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public bool Processed { get; set; }

        public List<ShipmentArticle> _shipmentArticles { get; set; }
    }
}
