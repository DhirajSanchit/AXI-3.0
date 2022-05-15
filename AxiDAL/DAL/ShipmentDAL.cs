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
    public class ShipmentDAL : IShipmentDAL
    {
        private IDbConnection _dbConnection;
        
        public ShipmentDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Retrieves all Shipments
        public IList<ShipmentDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * " + 
                      "FROM [Shipment]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<ShipmentDto>(sql).ToList();
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
        
        //Retrieves all unfinished shipments
        public IList<ShipmentDto> GetAllUnfinishedShipments()
        {
            //Prepare Query
            var sql = @"SELECT * " + 
                      "FROM [Shipment] " +
                      "WHERE Processed = 0";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<ShipmentDto>(sql).ToList();
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

        //Adds a new Shipment to the database and returns the id
        public int AddShipment(ShipmentDto shipmentDto)
        {
            //Prepare Queries
            var sql = @"insert into [Shipment] " +
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
                        shipmentDto.Date,
                        shipmentDto.InvoiceId,
                        shipmentDto.Name,
                        shipmentDto.Processed
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

        //Removes a Shipment from the database
        public void RemoveShipment(ShipmentDto shipmentDto)
        {
            //Prepare Query
            var sql = @"DELETE FROM [Shipment] WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql, shipmentDto.Id);
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

        //Updates a Shipment in the database
        public void UpdateShipment(ShipmentDto shipmentDto)
        {
            //Prepare Query
            var sql = @"UPDATE [Shipment] " +
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
                        shipmentDto.Date,
                        shipmentDto.InvoiceId,
                        shipmentDto.Name,
                        shipmentDto.Processed,
                        shipmentDto.Id
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
        
        //get a specific shipment from database
        public ShipmentDto GetShipmentById(int id)
        {
            //Prepare Query
            var sql = @"SELECT * FROM [Shipment] WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    return _dbConnection.QuerySingle<ShipmentDto>(sql, new { id });
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