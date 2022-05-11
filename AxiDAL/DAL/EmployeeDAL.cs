using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using Dapper;

namespace AxiDAL.DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private IDbConnection _dbConnection;

        public EmployeeDAL(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //retrieve all employees
        public IList<EmployeeDto> GetAll()
        {
            //Prepare Query
            var sql = @"SELECT * " +
                      "FROM [Employees]";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    return _dbConnection.Query<EmployeeDto>(sql).ToList();
                }
            }

            //Catches possible exceptions
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

            //Close connection
            finally
            {
                _dbConnection.Close();
            }
        }

        //Add employee
        public int AddEmployee(EmployeeDto employee)
        {
            //Prepare Queries
            var sql =
                @"INSERT INTO [Employee]" +
                " ([Name], " +
                "[Email], " +
                "[PhoneNr], " +
                "[Description]) " +
                "VALUES " +
                "(@Name, " +
                "@Email, " +
                "@PhoneNr, " +
                "@Description)";
            
            var sql2 = @"SELECT @@IDENTITY";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        employee.Name, 
                        employee.Email, 
                        employee.PhoneNr, 
                        employee.Description
                    });
                    return _dbConnection.QuerySingle<ArticleDto>(sql2, new
                    {
                        employee.Name, 
                        employee.Email, 
                        employee.PhoneNr, 
                        employee.Description
                    }).Id;
                }
            }

            //Catches possible exceptions
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

            //Close connection
            finally
            {
                _dbConnection.Close();
            }
        }

        //Update employee
        public void UpdateEmployee(EmployeeDto employee)
        {
            //Prepare Query
            var sql = @"UPDATE [Employee] " + 
                      "SET [Name] = @Name, " +
                      "[Email] = @Email, " +
                      "[PhoneNr] = @PhoneNr, " +
                      "[Description] = @Description " +
                      "WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        employee.Name, 
                        employee.Email, 
                        employee.PhoneNr, 
                        employee.Description, 
                        employee.Id
                    });
                }
            }

            //Catches possible exceptions
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

            //Close connection
            finally
            {
                _dbConnection.Close();
            }
        }

        //Delete employee
        public void DeleteEmployee(EmployeeDto employee)
        {
            //Prepare Query
            var sql = @"DELETE FROM [Employee] " +
                      "WHERE [Id] = @Id";

            //Execute statement
            try
            {
                using (_dbConnection)
                {
                    //Execute query on Database and return results
                    _dbConnection.Execute(sql, new
                    {
                        employee.Id
                    });
                }
            }

            //Catches possible exceptions
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

            //Close connection
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}