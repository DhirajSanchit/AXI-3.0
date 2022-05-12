using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private IDbConnection _dbConnection;
        private IList<ArticleDto> _dataset;

        public CategoryDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Get all categories
        public IList<string> GetAllCategories()
        {
            //Prepare Query
            var sql = @"SELECT Category FROM [Category]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<string>(sql).ToList();
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

        //add new category
        public void AddCategory(string category)
        {
            //Prepare Query
            var sql = @"INSERT INTO [Category] " +
                      "(Category) " +
                      "VALUES (@Category)";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql, new {category});
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
    }
}