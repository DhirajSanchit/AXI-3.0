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
        private IList<ShipmentDto> _dataset;

        public ShipmentDAL()
        {
            _dbConnection =
                new SqlConnection(
                    "Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;");
        }

        //Retrieves all Rows
        public IList<ShipmentDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * FROM [Shipment]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    _dataset = _dbConnection.Query<ShipmentDto>(sql).ToList();
                    return _dataset;
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

        public bool
            AddShipment(
                ShipmentDto shipmentDto)
        {
            const string sql =
                "insert into [Shipment] ([ShipmentDate], [InvoiceID], [ShipmentName], [Processed]) values(@Date, @InvoiceId, @Name, @Processed)";

            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        shipmentDto.Date,
                        shipmentDto.InvoiceId,
                        shipmentDto.Name,
                        shipmentDto.Processed
                    });
                    //possibly replace bool with int rowsAffected?
                    return true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.Close();
            }
        }

        public bool RemoveShipment(ShipmentDto shipmentDto)
        {
            const string sql = "DELETE FROM [Shipment] WHERE [ShipmentID] = @ShipmentId";

            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, shipmentDto.Id);
                }

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.Close();
            }
        }


        public bool UpdateShipment(ShipmentDto shipmentDto)
        {
            const string sql = "UPDATE [Shipment] " +
                               "Set [ShipmentDate] = @Date," +
                               "[InvoiceID] = @InvoiceId," +
                               "[ShipmentName] = @Name," +
                               "[Processed] = @Processed " +
                               "WHERE [ShipmentID] = @Id";

            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        shipmentDto.Date,
                        shipmentDto.InvoiceId,
                        shipmentDto.Name,
                        shipmentDto.Processed,
                        shipmentDto.Id
                    });
                    return true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            finally
            {
                _dbConnection.Close();
            }
        }
    }
}