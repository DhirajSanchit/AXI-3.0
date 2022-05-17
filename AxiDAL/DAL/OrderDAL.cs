using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private IDbConnection _dbConnection;
        
        public OrderDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Retrieves all Orders
        public IList<OrderDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * " + 
                      "FROM [Order]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<OrderDto>(sql).ToList();
                }
            }

            //Catches possible exceptions
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
        
        //Retrieves all unfinished orders
        public IList<OrderDto> GetAllUnfinishedOrders()
        {
            //Prepare Query
            var sql = @"SELECT * " + 
                      "FROM [Order] " +
                      "WHERE Processed = 0";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<OrderDto>(sql).ToList();
                }
            }

            //Catches possible exceptions
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

        //Adds a new Order to the database and returns the id
        public int AddOrder(OrderDto orderDto)
        {
            //Prepare Queries
            var sql = @"insert into [Order] " +
                      "values(@Date, @InvoiceId, @Name, @Processed)";

            var sql2 = @"SELECT @@IDENTITY";
            
            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return result
                    _dbConnection.Execute(sql, new
                    {
                        orderDto.Date,
                        orderDto.InvoiceId,
                        orderDto.Name,
                        orderDto.Processed
                    }); 
                    return _dbConnection.QuerySingle<int>(sql2);
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }

        //Removes a Order from the database
        public void RemoveOrder(OrderDto orderDto)
        {
            //Prepare Query
            var sql = @"DELETE FROM [Order] WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql, orderDto.Id);
                }
            }

            
            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }

        //Updates a Order in the database
        public void UpdateOrder(OrderDto orderDto)
        {
            //Prepare Query
            var sql = @"UPDATE [Order] SET " +
                               "Set [Date] = @Date," +
                               "[InvoiceID] = @InvoiceId," +
                               "[Name] = @Name," +
                               "[Processed] = @Processed " +
                               "WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                   _dbConnection.Execute(sql, new
                    {
                        orderDto.Date,
                        orderDto.InvoiceId,
                        orderDto.Name,
                        orderDto.Processed,
                        orderDto.Id
                    });
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }
        
        //get a specific order from database
        public OrderDto GetOrderById(int id)
        {
            //Prepare Query
            var sql = @"SELECT * FROM [Order] WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    return _dbConnection.QuerySingle<OrderDto>(sql, new { id });
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }
        
        public void UpdateOrderProgress(OrderDto orderDto)
        {
            //Prepare Query
            var sql = @"UPDATE [Order] " +
                               "Set [Processed] = @Processed " +
                               "WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql, new
                    {
                        orderDto.Processed,
                        orderDto.Id
                    });
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}