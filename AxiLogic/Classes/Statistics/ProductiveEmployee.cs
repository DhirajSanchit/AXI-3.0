using AxiDAL.DTOs.Statistics;

namespace AxiLogic.Classes.Statistics
{
    public class ProductiveEmployee
    {
        public string Name { get; set; }
        public int TotalProcessed { get; set; }
        
        public ProductiveEmployee(ProductiveEmployeeDto dto)
        {
           Name = dto.Name;
           TotalProcessed = dto.Total;
        }
        
        public ProductiveEmployee()
        {
            
        }
    }
}