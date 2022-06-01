using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs.Statistics;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class StatisticsDAL : IStatisticsDAL
    {
        private IDbConnection _dbConnection;

        public StatisticsDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// get top 5 most popular products
        /// </summary>
        public IList<PopularProductDto> getPopularProducts()
        {
            //prepare query
            var sql = @"with Amount_ordered as
                        (
                        select a.Id, a.Name, sum(Amount) AS Total
                        from OrderArticle o
                        join Article a on o.ArticleId = a.Id
                        group by a.Id, a.Name
                        )
                        select TOP 5 Id, Name, Total
                        from Amount_ordered
                        order by Total desc";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query and return result
                    return _dbConnection.Query<PopularProductDto>(sql).ToList();
                }
            }

            //catch exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result(s)
            finally
            {
                _dbConnection.Close();
            }
        }

        /// <summary>
        /// get top 5 most productive employees
        /// </summary>
        public IList<ProductiveEmployeeDto> GetProductiveEmployees()
        {
            //prepare query
            var sql = @"with StockEmployees as
                        (
                            select DISTINCT e.Name, e.Id
                            from Employee e
                            left join StockEmployee s on e.Id = s.EmployeeId
                        ),
                        Amount_Employee_Orders as
                        (
                            select DISTINCT Employee_Id, count(OrderId) AS Amount_Orders
                            from SE_Order 
                            group by Employee_Id
                        ),
                        Amount_Employee_Delivery as
                        (
                            select DISTINCT EmployeeId, count(ShipmentId) AS Amount_Deliveries
                            from SE_Shipment 
                            group by EmployeeId
                        )
                        
                        select TOP 5 s1.Name, sum(a1.Amount_Orders + a2.Amount_Deliveries) AS Total
                        from StockEmployees s1
                        left join Amount_Employee_Orders a1 on s1.Id = a1.Employee_Id
                        left join Amount_Employee_Delivery a2 on s1.Id = a2.EmployeeId
                        group by s1.Name
                        order by Total desc";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query and return result
                    return _dbConnection.Query<ProductiveEmployeeDto>(sql).ToList();
                }
            }

            //catch exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result(s)
            finally
            {
                _dbConnection.Close();
            }
        }

        /// <summary>
        /// get top 5 categories in stock
        /// </summary>
        public IList<AmountInCategoryDto> GetBiggestCategories()
        {
            //prepare query
            var sql = @"select c.Name AS CategoryName, sum(s.Amount) AS Amount
                        from Article a
                        join Category c on a.Category = c.Id
                        join Stock s on a.Id = s.ArticleId
                        group by c.Name
                        order by Amount desc";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query and return result
                    return _dbConnection.Query<AmountInCategoryDto>(sql).ToList();
                }
            }

            //catch exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result(s)
            finally
            {
                _dbConnection.Close();
            }
        }

        /// <summary>
        /// get top 5 months by amount of orders
        /// </summary>
        public IList<OrdersPerMonthDto> GetOrdersPerMonth()
        {
            //prepare query
            var sql = @"select TOP 5 Month, sum(Id) AS Amount
                        from
                        (
                            select Id, DATENAME(MONTH, Date) AS Month
                            from ClientOrder
                        )t
                        group by Month
                        order by Amount desc";


            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query and return result
                    return _dbConnection.Query<OrdersPerMonthDto>(sql).ToList();
                }
            }

            //catch exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result(s)
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}