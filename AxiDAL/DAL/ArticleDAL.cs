using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class ArticleDAL : IArticleDAL
    {

        private IDbConnection _dbConnection;
        public IList<ArticleDto> dataset;

        public ArticleDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
         
        
        public IList<ArticleDto> GetAll()
        {
            var sql = @"SELECT * FROM [Article]";

                try
                {

                    using (_dbConnection)
                    {
                        // var tests = (IList<TestDto>) await _dbConnection.QueryAsync("sql");
                        var dataset = /*(IList<TestDto>)*/ _dbConnection.Query<ArticleDto>(sql).ToList();
                        return dataset;
                    }
                }
                catch (Exception ex)
                {
                
                    Console.WriteLine(ex.Message); 
                    throw new Exception(ex.Message);
                }
            }
        

        public ArticleDto GetById()
        {
            throw new System.NotImplementedException();
        }

        public bool AddArticle()
        {
            throw new System.NotImplementedException();
        }
    }
}
