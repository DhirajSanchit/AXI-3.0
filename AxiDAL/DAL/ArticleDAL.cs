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

        private IDbConnection _dbConnection;
        private IList<ArticleDto> _dataset;
        //private const string connectionstring = ""Server=mssqlstud.fhict.local;Database=dbi484674;User Id = dbi484674; Password=DatabaseAXItim;"
        
        //Assign connectionstring from appsettings.json
        public ArticleDAL()
        {
            _dbConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi484674;User Id = dbi484674;Password=DatabaseAXItim;");
        }
        
        public ArticleDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        //Retrieves all articles
        public IList<ArticleDto> GetAll()
        {   
            //Prepare Query
            var sql = @"SELECT * FROM [Article]";
                
            //Execute statement
                try
                {
                    using (_dbConnection)
                    {   
                        //Execute query on Database, and return _dataset
                        return _dbConnection.Query<ArticleDto>(sql).ToList();
                    }
                }
                
                //TODO: Catch and handle possible exceptions
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
        
        
        public ArticleDto GetByBarcode(ArticleDto articleDto)
        {
            const string sql = "Select * From [Article] Where Barcode = @Barcode";
            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new
                    {
                        articleDto.Barcode
                    });
                    return articleDto;
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

        public int AddArticle(ArticleDto articleDto)
        {
            const string sql = "insert into [Article] values(@Name, @Price, @ImgRef, @Category, @Description)";
            const string sql2 = "SELECT ID FROM [Article] WHERE [Name] = @Name, [Price] = @Price, [ImgRef] = @ImgRef, [Category] = @Category, [Description] = @Description)";
            try
            {
                using (_dbConnection)
                {
                    var result = _dbConnection.Execute(sql, new 
                        {
                         articleDto.Name,
                         articleDto.Price,
                         articleDto.ImgRef,
                         articleDto.Category,
                         articleDto.Description 
                        });
                    return _dbConnection.QuerySingle<ArticleDto>(sql2).Id;
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

        public void UpdateArticle(ArticleDto articleDto)
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

        public void DeleteArticle(ArticleDto articleDto)
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
