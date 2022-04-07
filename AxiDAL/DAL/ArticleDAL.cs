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
        
        
        public ArticleDto GetById()
        {
            throw new System.NotImplementedException();
        }

        public bool AddArticle()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateArticle()
        {
            throw new NotImplementedException();
        }

        public bool DeleteArticle()
        {
            throw new NotImplementedException();
        }
    }
}
