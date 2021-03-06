using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper; 

namespace AxiDAL.DAL
{
    public class TestDAL : ITestDAL
    {
        
        /* Purpose of the TestDAL & Container:
         * testing if the proof of concept works. If the connection works, extrapolate on the other DAL's
         *  and containers
         */
        
        
        private IDbConnection _dbConnection;
        
        public TestDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public IList<TestDTO> GetAllTestData()
        {
            var sql = @"SELECT [id], [value] FROM [Test]";

            try
            {

                using (_dbConnection)
                {
                    // var tests = (IList<TestDto>) await _dbConnection.QueryAsync("sql");
                    var tests = /*(IList<TestDto>)*/ _dbConnection.Query<TestDTO>(sql).ToList();
                    return tests;
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