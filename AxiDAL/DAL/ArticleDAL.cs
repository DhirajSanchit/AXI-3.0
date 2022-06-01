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
            var sql =
                @"SELECT A.ID, A.Name, Category AS CategoryId, C.Name AS CategoryName, Price,BarCode, Img, A.Disabled
                         FROM Article A
                         JOIN Category C on Category = C.ID 
                         WHERE Disabled = 0 ";
                
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
            var sql = "Select * From [Article] Where Barcode = @Barcode AND Disabled = 0";
            
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
                "[CategoryName] = @CategoryName " +
                "[Description] = @Description " +
                "[Disabled] = @Disabled" +
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
                        articleDto.CategoryName,
                        articleDto.Description,
                        articleDto.Barcode,
                        articleDto.Disabled
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

        //get article by AricleId in palletDTO
        public ArticleDto GetFromPallet(PalletDto palletDto)
        {
            //Prepare Queries
            var sql = "Select * from [Article] " +
                "Where Id = @ArticleId";
            
            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.QuerySingle<ArticleDto>(sql, new
                    {
                        palletDto.ArticleId
                    });
                }
            }
            
            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<ArticleDto> GetByCategory(CategoryDto categoryDto)
        {
            //Prepare Queries
            var sql = "Select * from [Article] " +
                "Where Category = @Id AND Disabled = 0";
            //todo change Category in article to categoryId?
                "Where CategoryName = @Id";
            //todo change CategoryName in article to categoryId?

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.Query<ArticleDto>(sql, new
                    {
                        categoryDto.Id
                    }).ToList();
                }
            }
            
            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        
        public void RemoveCategory(ArticleDto articleDto)
        {
            //Prepare Queries
            var sql = "Update [Article] " +
                "Set [Category] = null " +
                "Where [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        articleDto.Id
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

        public ArticleDto GetArticleById(int Id)
        {
            //Prepare Queries
            var sql = "Select * from [Article] " +
                "Where Id = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.QuerySingle<ArticleDto>(sql, new
                    {
                        Id
                    });
                }
            }
            
            //Catches possible exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
