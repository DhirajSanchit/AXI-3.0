using System.Collections.Generic;
using AxiDAL.DTOs.Statistics;

namespace AxiLogic.Interfaces
{
    public interface IStatContainer
    {
        public (List<AmountInCategoryDto>, List<OrdersPerMonthDto>, List<PopularProductDto>, List<ProductiveEmployeeDto>) GetStatistics();
    }
}