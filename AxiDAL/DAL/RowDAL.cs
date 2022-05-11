using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AxiDAL.DAL
{
    public class RowDAL : IRowDAL
    {
        private IDbConnection _dbConnection;
        
        public RowDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Retrieves all Rows
        public IList<RowDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * " + 
                      "FROM [Row_Table]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<RowDto>(sql).ToList();
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
        
        //Add row to database
        public int AddRow(RowDto rowDto)
        {
            //Prepare Query
            var sql1 = @"insert into [Row_Table] values(@Name)";
            
            var sql2 = @"SELECT @@IDENTITY";
            
            //Execute statement
            try
            {
                using (_dbConnection)
                { 
                    //Execute query on Database, and return results
                    _dbConnection.Execute(sql1, new
                    {
                        rowDto.Name
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

            //Close Connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        //Update row in database
        public void UpdateArticle(RowDto rowDto)
        {
            //Prepare Query
            var sql = "Update [Row_Table] " +
                "Set [Name] = @Name";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return results
                    _dbConnection.Execute(sql, new
                    {
                       rowDto.Name,
                    });
                }
            }
            
            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            
            //Close Connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        //Delete row from database
        public void DeleteArticle(RowDto rowDto)
        {
            //Prepare Query
            var sql = "Delete from [Row_Table] " +
                "Where [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return results
                    _dbConnection.Execute(sql, new
                    {
                        rowDto.Id
                    });
                }
            }
            
            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            
            //Close Connection
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
