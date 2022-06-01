using System.Collections.Generic;
using System.Linq;
using AxiDAL.DTOs.Statistics;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Classes.Statistics;
using AxiLogic.Interfaces;

namespace AxiLogic.Containers
{
    public class StatContainer : IStatContainer
    {
        public List<AmountInCategory> AmountInCategories { get; set; }
        public List<OrdersPerMonth> OrdersPerMontList { get; set; }
        public List<PopularProduct> PopularProducts { get; set; }
        public List<ProductiveEmployee> ProductiveEmployees { get; set; }
       
        private IDalFactory _idalFactory;
        
        public StatContainer(DalFactory idalFactory)
        {
            _idalFactory = idalFactory;
            AmountInCategories = new List<AmountInCategory>();
            OrdersPerMontList = new List<OrdersPerMonth>();
            PopularProducts = new List<PopularProduct>();
            ProductiveEmployees = new List<ProductiveEmployee>();
        }
        
        public (List<AmountInCategoryDto>, List<OrdersPerMonthDto>, List<PopularProductDto>, List<ProductiveEmployeeDto>) GetStatistics()
        {
            //get all statistics
            var amountInCategories = _idalFactory.GetStatisticsDal().GetBiggestCategories();
            var ordersPerMontList = _idalFactory.GetStatisticsDal().GetOrdersPerMonth();
            var popularProducts = _idalFactory.GetStatisticsDal().getPopularProducts();
            var productiveEmployees = _idalFactory.GetStatisticsDal().GetProductiveEmployees();
            
            //put all dto's in container as classes
            foreach (var amountInCategoryDto in amountInCategories)
            {
                AmountInCategories.Add(new AmountInCategory(amountInCategoryDto));
            }
            
            foreach (var ordersPerMonthDto in ordersPerMontList)
            {
                OrdersPerMontList.Add(new OrdersPerMonth(ordersPerMonthDto));
            }
            
            foreach (var popularProductDto in popularProducts)
            {
                PopularProducts.Add(new PopularProduct(popularProductDto));
            }
            
            foreach (var productiveEmployeeDto in productiveEmployees)
            {
                ProductiveEmployees.Add(new ProductiveEmployee(productiveEmployeeDto));
            }


            return (amountInCategories.ToList(), ordersPerMontList.ToList(), popularProducts.ToList(), productiveEmployees.ToList());
        }
        
    }
}