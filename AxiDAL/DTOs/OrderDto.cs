using System;
using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct OrderDto
    {
        public DateTime Date;
        public int InvoiceId;
        public string Name;
        public int Id;
        public bool Processed;
        public List<OrderArticleDto> OrderArticles;
    }
}