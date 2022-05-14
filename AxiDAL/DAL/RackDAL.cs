using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class RackDAL : IRackDAL
    {
        private IDbConnection _dbConnection;

        public RackDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// retrieves all racks
        /// </summary>
        public IList<RackDto> GetAllFromRow(RowDto row)
        {
            //prepare query
            var sql = @"SELECT * " +
                      "FROM [Rack] " +
                      "WHERE [RowId] = @Id";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return results
                    return _dbConnection.Query<RackDto>(sql, new
                    {
                        row.Id
                    }
                    ).ToList();
                }
            }

            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }

            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }


        /// <summary>
        /// add a new rack
        /// variables: RowId, Location
        /// </summary>
        public int AddRack(RackDto rack)
        {
            //prepare queries
            var sql = @"INSERT INTO [Rack] " +
                      "(RowId, Location) " +
                      "VALUES " +
                      "(@RowId, @Location)";

            var sql2 = @"SELECT @@IDENTITY";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        rack.RowId,
                        rack.Location
                    });
                    return _dbConnection.QuerySingle<int>(sql2);
                }
            }

            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }

            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        /// <summary>
        /// Update rack
        /// </summary>
        public void UpdateRack(RackDto rack)
        {
            //prepare query
            var sql = @"UPDATE [Rack] " +
                      "SET Location = @Location, " +
                      "RowId = @RowId " +
                      "WHERE Id = @Id";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        rack.Id,
                        rack.Location,
                        rack.RowId
                    });
                }
            }
            
            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
            
            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        /// <summary>
        /// delete rack
        /// </summary>
        public void DeleteRack(RackDto rack)
        {
            //prepare query 
            var sql = @"DELETE FROM [Rack] " +
                      "WHERE Id = @Id";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        rack.Id
                    });
                }
            }
            
            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
            
            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
