using System.Collections.Generic;
using AxiDAL.DTOs.Statistics;

namespace AxiLogic.Classes.Statistics
{
    public class PopularProduct
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Total { get; set; }
        
        public PopularProduct(PopularProductDto dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            Total = dto.Total;
        }
        
        public PopularProduct()
        {
        }
    }
}   