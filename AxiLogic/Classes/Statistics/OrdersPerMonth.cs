using AxiDAL.DTOs.Statistics;

namespace AxiLogic.Classes.Statistics
{
    public class OrdersPerMonth
    {
        public string Month { get; set; }
        public int Orders { get; set; }
        
        public OrdersPerMonth(OrdersPerMonthDto dto)
        {
            Month = dto.Month;
            Orders = dto.Amount;
        }
        
        public OrdersPerMonth()
        {
            
        }
    }
}