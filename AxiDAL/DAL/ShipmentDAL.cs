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
        //add
        //remove
        //getall
        //update

        private IDbConnection _dbConnection;
        private IList<ShipmentDto> _dataset;
        
        //Assign connectionstring from appsettings.json
        public ShipmentDAL()
        {
            _dbConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;");
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
    }
}
