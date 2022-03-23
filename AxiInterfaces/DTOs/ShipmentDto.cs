using System;
using System.Collections.Generic;

namespace AxiInterfaces.DTOs
{
    public class ShipmentDto
    {
        public DateTime Date { get; private set; }
        public int InvoiceId { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }
    }
}