using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class OrderArticleDAL : IOrderArticleDAL
    {
         private IDbConnection _dbConnection;

        public OrderArticleDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //retrieves all order articles
        public IList<OrderArticleDto> GetAllOrderArticlesFromOrder(OrderDto order)
        {
            //Prepare query
            var sql = @"SELECT * FROM [OrderArticle]" +
                      "WHERE [OrderId] = @OrderId";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return result
                    return _dbConnection.Query<OrderArticleDto>(sql, new {OrderId = order.Id}).ToList();
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                _dbConnection.Close();
            }
        }

        //Add new order article
        public void AddOrderArticle(OrderArticleDto orderArticle)
        {
            //Prepare queries
            var sql = @"INSERT INTO [OrderArticle] " +
                      "values (@OrderId, @ArticleId, @Amount, @ScannedAmount)";

            var sql2 = @"Select @@IDENTITY";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute queries on database
                    _dbConnection.Execute(sql, new
                    {
                        orderArticle.OrderId,
                        orderArticle.Article.Id,
                        orderArticle.Amount,
                        orderArticle.ScannedAmount
                    });
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                _dbConnection.Close();
            }
        }

        //Update order article
        public void UpdateOrderArticle(OrderArticleDto orderArticle)
        {
            //Prepare query
            var sql = @"UPDATE [OrderArticle] " +
                      "Set [Amount] = @Amount, " +
                      "[ScannedAmount] = @ScannedAmount " +
                      "WHERE [OrderId] = @OrderId " +
                      "AND [ArticleId] = @ArticleId";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        orderArticle.Amount,
                        orderArticle.ScannedAmount,
                        orderArticle.OrderId,
                        orderArticle.Article.Id
                    });
                }
            }
            
            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //closes database connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        //Delete order article
        public void DeleteOrderArticle(OrderArticleDto orderArticle)
        {
            //Prepare query
            var sql = @"DELETE FROM [OrderArticle] " + 
                      "WHERE [OrderId] = @OrderId " + 
                      "AND [ArticleId] = @ArticleId";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        orderArticle.OrderId,
                        orderArticle.Article.Id
                    });
                }
            }
            
            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //closes database connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        public void UpdateOrderArticleProgress(OrderArticleDto orderArticleDto)
        {
            //Prepare query
            var sql = @"UPDATE [OrderArticle] " +
                      "SET [ScannedAmount] = @ScannedAmount " +
                      "WHERE [OrderId] = @OrderId " +
                      "AND [ArticleId] = @ArticleId";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        orderArticleDto.ScannedAmount,
                        orderArticleDto.OrderId,
                        orderArticleDto.ArticleId
                    });
                }
            }
            
            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //closes database connection
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}