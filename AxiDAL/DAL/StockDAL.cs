using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiDAL.DAL
{
    public class StockDAL : IStockDAL
    {
        private IDbConnection _dbConnection;

        public StockDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Retrieves all stocks
        public IList<StockDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT Name, Amount,  Id " +
                       "FROM Article, Stock " +
                       "WHERE Article.Id = Stock.ArticleId";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.Query<StockDto>(sql).ToList();
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
