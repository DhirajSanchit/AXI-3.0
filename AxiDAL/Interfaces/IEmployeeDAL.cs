using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IEmployeeDAL
    {
        public IList<EmployeeDto> GetAll();
        public int AddEmployee(EmployeeDto employee);
        public void UpdateEmployee(EmployeeDto employee);
        public void DeleteEmployee(EmployeeDto employee);
    }
}