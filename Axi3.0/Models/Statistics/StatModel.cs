using System.Collections.Generic;

namespace Axi3._0.Models.Statistics
{
    public class StatModel
    {
        public List<CategoryAmount> CategoryAmounts;
        public List<ProductiveEmployee> ProductiveEmployees;
        public List<OrdersPerMonth> OrdersPerMonth;
        public List<PopularProduct> PopularProduct;

        public StatModel()
        {
            CategoryAmounts = new List<CategoryAmount>();
            ProductiveEmployees = new List<ProductiveEmployee>();
            OrdersPerMonth = new List<OrdersPerMonth>();
            PopularProduct = new List<PopularProduct>();
        }
    }
}