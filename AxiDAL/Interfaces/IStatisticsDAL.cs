using System.Collections.Generic;
using AxiDAL.DTOs.Statistics;

namespace AxiDAL.Interfaces
{
    public interface IStatisticsDAL
    {
        public IList<PopularProductDto> getPopularProducts();
        public IList<ProductiveEmployeeDto> GetProductiveEmployees();
        public IList<AmountInCategoryDto> GetBiggestCategories();
        public IList<OrdersPerMonthDto> GetOrdersPerMonth();
    }
}