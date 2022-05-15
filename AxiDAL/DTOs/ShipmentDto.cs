using System;
using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct ShipmentDto
    {
        public DateTime Date;
        public int InvoiceId;
        public string Name;
        public int Id;
        public bool Processed;
        public List<ShipmentArticleDto> ShipmentArticles;
    }
}