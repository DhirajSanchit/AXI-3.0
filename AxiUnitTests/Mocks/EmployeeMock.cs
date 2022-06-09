using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiUnitTests.Scrubs // to do
{
    public class EmployeeMock : IEmployeeDAL
    {
        public IList<EmployeeDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public int AddEmployee(EmployeeDto employee)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEmployee(EmployeeDto employee)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEmployee(EmployeeDto employee)
        {
            throw new System.NotImplementedException();
        }
    }
}