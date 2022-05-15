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
    public class ShipmentArticleDAL : IShipmentArticleDAL
    {
        private IDbConnection _dbConnection;

        public ShipmentArticleDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //retrieves all shipment articles
        public IList<ShipmentArticleDto> GetAllShipmentArticlesFromShipment(ShipmentDto shipment)
        {
            //Prepare query
            var sql = @"SELECT * FROM [ShipmentArticle]" +
                      "WHERE [ShipmentId] = @ShipmentId";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return result
                    return _dbConnection.Query<ShipmentArticleDto>(sql, new {ShipmentId = shipment.Id}).ToList();
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

        //Add new shipment article
        public int AddShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            //Prepare queries
            var sql = @"INSERT INTO [ShipmentArticle] " +
                      "values (@ShipmentId, @ArticleId, @Amount, @ScannedAmount)";

            var sql2 = @"Select @@IDENTITY";

            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute queries on database
                    _dbConnection.Execute(sql, new
                    {
                        shipmentArticle.ShipmentId,
                        shipmentArticle.Article.Id,
                        shipmentArticle.Amount,
                        shipmentArticle.ScannedAmount
                    });

                    //get id of inserted shipment article
                    return _dbConnection.QuerySingle<int>(sql2);
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

        //Update shipment article
        public void UpdateShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            //Prepare query
            var sql = @"UPDATE [ShipmentArticle] " +
                      "Set [Amount] = @Amount, " +
                      "[ScannedAmount] = @ScannedAmount " +
                      "WHERE [ShipmentId] = @ShipmentId " +
                      "AND [ArticleId] = @ArticleId";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        shipmentArticle.Amount,
                        shipmentArticle.ScannedAmount,
                        shipmentArticle.ShipmentId,
                        shipmentArticle.Article.Id
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
        
        //Delete shipment article
        public void DeleteShipmentArticle(ShipmentArticleDto shipmentArticle)
        {
            //Prepare query
            var sql = @"DELETE FROM [ShipmentArticle] " + 
                      "WHERE [ShipmentId] = @ShipmentId " + 
                      "AND [ArticleId] = @ArticleId";
            
            //execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database
                    _dbConnection.Execute(sql, new
                    {
                        shipmentArticle.ShipmentId,
                        shipmentArticle.Article.Id
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