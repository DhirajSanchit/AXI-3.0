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
        private IList<PalletDto> _dataset;

        public PalletDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IList<PalletDto> GetAll()
        {
            var sql = "Select * From [Pallet]";

            try
            {
                using (_dbConnection)
                {
                    _dataset = _dbConnection.Query<PalletDto>(sql).ToList();
                    return _dataset;
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

        public bool AddPallet(PalletDto palletDto)
        {
            var sql = "Insert Into [Pallet] Values(@ArticleId, @PlankId, @Location, @)";
            return true; //temp true, change later!!!
        }
        
    }
}
