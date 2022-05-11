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

        //Retrieves all articles
        public IList<PlankDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * " +
                      "FROM [Plank]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.Query<PlankDto>(sql).ToList();
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
        public int AddPlank(PlankDto PlankDto)
        {
            //Prepare Queries
            var sql = "insert into [Plank] " +
                               "values(@RackId, " +
                               "@Location";

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
                    return _dbConnection.QuerySingle<ArticleDto>(sql2, new
                    {
                        PlankDto.RackId,
                        PlankDto.Location
                    }).Id;
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
                "[Location] = @Location";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        plankDto.RackId,
                        plankDto.Location
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

        public void RemovePlank(PlankDto plankDto)
        {
            //Prepare Queries
            var sql = "Delete from [Plank] " +
                "Where ID = @Id";

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
