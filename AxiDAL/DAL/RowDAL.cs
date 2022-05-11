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
        private IList<ArticleDto> _dataset;
        
        //Assign connectionstring from appsettings.json
        public RowDAL()
        {
            _dbConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;");
        }

        public RowDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Retrieves all Rows
        public IList<ArticleDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * FROM [Row]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return (IList<ArticleDto>)_dbConnection.Query<RowDto>(sql).ToList();
                }
            }

            //TODO: Catch and handle possible exceptions
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
        public int AddRow(RowDto rowDto)
        {
            const string sql1 = "insert into [Row] values(@Name)";
            const string sql2 = "Select ID From [Row] Where [Name] = @Name";
            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql1, new
                    {
                        rowDto.Name
                    });
                    //possibly replace bool with int rowsAffected?
                    return _dbConnection.QuerySingle<RowDto>(sql2).Id;
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
        
        public void UpdateArticle(RowDto rowDto)
        {
            const string sql = "Update [Row] " +
                "Set [Name] = @Name";

            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        @Name = rowDto.Name,
                    });
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
        
        public void DeleteArticle(RowDto rowDto)
        {
            const string sql = "Delete from [Row] " +
                "Where Name = @Name";

            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        rowDto.Name
                    });
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
