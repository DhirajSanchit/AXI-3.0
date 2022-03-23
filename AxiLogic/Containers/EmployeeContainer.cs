using System;
using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{
    public class EmployeeContainer
    {
        private List<Employee> _employees = new List<Employee>();
        
        
        public IReadOnlyCollection<Employee> GetEmployees()
        {
            return _employees;
        }
        
        public void AddEmployee(Employee employee)
        {
            if (_employees.Contains(employee))
            {
                throw new ArgumentException("Cannot add duplicate employee to list");
            } 
            _employees.Add(employee);
        }
        
        public void RemoveEmployee(Employee employee)
        {
            if (!_employees.Contains(employee))
            {
                throw new ArgumentException("Cannot remove non-contained employee from list");
            }
            _employees.Remove(employee);
        }
    }
}