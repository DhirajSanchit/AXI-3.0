using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class PlankDAL : IPlankDAL
    {
        private IDbConnection _dbConnection;

        public PlankDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Retrieves all planks
        public IList<PlankDto> GetAllFromRack(RackDto rack)
        {
            //Prepare Query
            var sql = @"SELECT * " +
                      "FROM [Plank] " +
                      "WHERE [RackId] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.Query<PlankDto>(sql, new 
                    {
                        rack.Id
                    }
                    ).ToList();
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            // Closes DB connection when finishing statement regardless of result(s)
            finally
            {
                _dbConnection.Close();
            }
        }
        
        //Add plank to database
        public int AddPlank(PlankDto PlankDto)
        {
            //Prepare Queries
            var sql = "insert into [Plank] " +
                               "values(@RackId, " +
                               "@Location)";
            
            var sql2 = @"Select @@IDENTITY";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        PlankDto.RackId,
                        PlankDto.Location
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

            // Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }

        public void UpdatePlank(PlankDto plankDto)
        {
            //Prepare Queries
            var sql = @"Update [Plank] " +
                "Set [RackID] = @RackId " +
                "[Location] = @Location " +
                "Where [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        plankDto.RackId,
                        plankDto.Location,
                        plankDto.Id
                    });
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            // Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }

        public void DeletePlank(PlankDto plankDto)
        {
            //Prepare Queries
            var sql = "Delete from [Plank] " +
                "Where [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        plankDto.Id
                    });
                }
            }

            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            // Closes DB connection when finishing statement regardless of result
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
