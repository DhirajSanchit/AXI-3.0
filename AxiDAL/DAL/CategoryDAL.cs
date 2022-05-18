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
        public IList<CategoryDto> GetAllCategories()
        {
            //Prepare Query
            var sql = @"SELECT * FROM [Category]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database, and return _dataset
                    return _dbConnection.Query<CategoryDto>(sql).ToList();
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
        public void AddCategory(CategoryDto categoryDto)
        {
            //Prepare Query
            var sql = @"INSERT INTO [Category] " +
                      "(Name) " +
                      "VALUES (@Name)";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql, new {categoryDto.Name});
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
        
        //Remove existing Category
        public void RemoveCategory(int id)
        {
            //Prepare Query
            var sql1 = @"DELETE FROM [Category] WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql1, new {Id = id});
                    //var affectedRows = _dbConnection.Execute(delete_sql, new {CheckinId = id});
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
        
        //update existing Category
        public void UpdateCategory(CategoryDto categoryDto)
        {
            //Prepare Query
            var sql = @"UPDATE [Category] SET [Name] = @Name WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database
                    _dbConnection.Execute(sql, new {categoryDto.Name, categoryDto.Id});
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