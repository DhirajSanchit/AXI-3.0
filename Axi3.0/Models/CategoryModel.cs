using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiLogic.Classes;

namespace Axi3._0.Models
{
    public class CategoryModel
    {
        public IList<CategoryDto> Categories { get; set; }
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}