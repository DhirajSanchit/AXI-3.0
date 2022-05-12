﻿using System;
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
          
        //private IList<ArticleDto> _dataset;
        //private const string connectionstring = ""Server=mssqlstud.fhict.local;Database=dbi484674;User Id = dbi484674; Password=DatabaseAXItim;"

        public ArticleDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        //Retrieves all articles
        public IList<ArticleDto> GetAll()
        {   
            //Prepare Query
            var sql = @"SELECT * " +
                      "FROM [Article]";
                
            //Execute statement
                try
                {
                    using (_dbConnection)
                    {   
                        //Execute query on Database and return results
                        return _dbConnection.Query<ArticleDto>(sql).ToList();
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
        
        public ArticleDto GetByBarcode(ArticleDto articleDto)
        {
            //Prepare Query
            var sql = "Select * From [Article] Where Barcode = @Barcode";
            
            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.QuerySingle<ArticleDto>(sql, new
                    {
                        articleDto.Barcode
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

        public int AddArticle(ArticleDto articleDto)
        {
            //Prepare Queries
            var sql = "insert into [Article] " + 
                               "values(@Name, " +
                               "@Price, " +
                               "@ImgRef, " +
                               "@Category, " +
                               "@Description)";
            
            var sql2 = @"Select @@IDENTITY";
           
            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new 
                        {
                            articleDto.Name, 
                            articleDto.Price,
                            articleDto.ImgRef,
                            articleDto.Category,
                            articleDto.Description 
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

        public void UpdateArticle(ArticleDto articleDto)
        {
            //Prepare Queries
            var sql = @"Update [Article] " +
                "Set [Name] = @Name," +
                "[Price] = @Price," +
                "[ImgRef] = @ImgRef " +
                "[Category] = @Category " +
                "[Description] = @Description " +
                "Where Barcode = @Barcode";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                   _dbConnection.Execute(sql, new
                    {
                        articleDto.Name,
                        articleDto.Price,
                        articleDto.ImgRef,
                        articleDto.Category,
                        articleDto.Description,
                        articleDto.Barcode
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

        public void DeleteArticle(ArticleDto articleDto)
        {
            //Prepare Queries
            var sql = "Delete from [Article] " +
                "Where Barcode = @Barcode";

            //Execute statement
            try
            {
                using(_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        articleDto.Barcode
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
