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
    public class ArticleDAL : IArticleDAL
    {
        private const string Connectionstring =
            "Server=mssqlstud.fhict.local;Database=dbi484674;User Id=dbi484674;Password=DatabaseAXItim;";
        private IDbConnection _dbConnection;
        private IList<ArticleDto> _dataset;
        
        //Assign connectionstring from appsettings.json
        public ArticleDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
         
        //Rtetrieves all articles
        public IList<ArticleDto> GetAll()
        {   
            //Prepary Query
            var sql = @"SELECT * FROM [Article]";
                
            //Execute statement
                try
                {
                   
                    using (_dbConnection)
                    {   
                        //Execute query on Database, and return _dataset
                        _dataset = _dbConnection.Query<ArticleDto>(sql).ToList();
                        return _dataset;
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
        
        
        public ArticleDto GetByBarcode()
        {
            
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Select * From [Article] Where Barcode = @Barcode";

            ArticleDto articleDto = new();
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@Barcode", articleDto.Id);
            }

            connection.Close();
            return articleDto;
        }

        public bool AddArticle(ArticleDto articleDto)
        {
            const string sql = "insert into [Article] values(@Name, @Price, @ImgRef, @Category, @Description)";
            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new 
                        {
                         @Name = articleDto.Name,
                         @Price = articleDto.Price,
                         @ImgRef = articleDto.ImgRef,
                         @Category = articleDto.Category,
                         @Description = articleDto.Description 
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

        public bool UpdateArticle(ArticleDto articleDto)
        {
            const string sql = "Update [Article] " +
                "Set [Name] = @Name," +
                "[Price] = @Price," +
                "[ImgRef] = @ImgRef " +
                "[Category] = @Category " +
                "[Description] = @Description " +
                "Where Barcode = @Barcode";

            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        @Name = articleDto.Name,
                        @Price = articleDto.Price,
                        @ImgRef = articleDto.ImgRef,
                        @Category = articleDto.Category,
                        @Description = articleDto.Description,
                        @Barcode = articleDto.Barcode
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

        public bool DeleteArticle(ArticleDto articleDto)
        {
            const string sql = "Delete from [Article] " +
                "Where Barcode = @Barcode";

            try
            {
                using(_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        @Barcode = articleDto.Barcode
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
