using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AxiDAL.DAL
{
    public class PalletDAL : IPalletDAL
    {
        private IDbConnection _dbConnection;

        public PalletDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //Get all pallets
        public IList<PalletDto> GetAll()
        {
            //Prepare query
            var sql = @"Select * " +
                      "From [Pallet]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return result
                    return _dbConnection.Query<PalletDto>(sql).ToList();
                }
            }

            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }

        //Add a pallet to the database
        //variables: ArticleId, PlankId, Amount, Location
        public int AddPallet(PalletDto palletDto)
        {
            //Prepare queries
            var sql = @"Insert Into [Pallet] " +
                      "([ArticleId], " +
                      "[PlankId], " +
                      "[Amount], " +
                      "[Location]) " +
                      "Values " +
                      "(@ArticleId, " +
                      "@PlankId, " +
                      "@Amount, " +
                      "@Location)";

            var sql2 = @"Select @@IDENTITY";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return result
                    _dbConnection.Execute(sql, new
                    {
                        palletDto.Article.Id,
                        palletDto.PlankId,
                        palletDto.Amount,
                        palletDto.Location
                    });

                    return _dbConnection.QuerySingle<int>(sql2);
                }
            }

            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }
        
        //Update a pallet in the database
        //variables: Id, ArticleId, PlankId, Amount, Location
        public void UpdatePallet(PalletDto palletDto)
        {
            //Prepare query
            var sql = @"Update [Pallet] " + 
                      "Set [ArticleId] = @ArticleId, " +
                      "[PlankId] = @PlankId, " +
                      "[Amount] = @Amount, " +
                      "[Location] = @Location " +
                      "Where [Id] = @Id";
            
            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return result
                    _dbConnection.Execute(sql, new
                    {
                        palletDto.Id,
                        ArticleId = palletDto.Article.Id,
                        palletDto.PlankId,
                        palletDto.Amount,
                        palletDto.Location
                    });
                }
            }
            
            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            
            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }
            
        
        //Delete a pallet from the database
        //variables: Id
        public void DeletePallet(PalletDto palletDto)
        {
            //Prepare query
            var sql = @"Delete From [Pallet] " +
                      "Where [Id] = @Id";
            
            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //execute query on database and return result
                    _dbConnection.Execute(sql, new
                    {
                        palletDto.Id
                    });
                }
            }
            
            //catch any errors
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            
            //close connection
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
