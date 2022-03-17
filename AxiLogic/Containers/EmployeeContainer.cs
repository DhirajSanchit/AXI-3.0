using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{
    public class EmployeeContainer
    {
        private List<Employee> _employees;

        public EmployeeContainer(List<Employee> employees)
        {
            _employees = employees;
        }
        
        public IReadOnlyCollection<Employee> GetEmployees()
        {
            return _employees;
        }
        
        public void AddEmployee(Employee employee)
        {
           _employees.Add(employee);
        }
        
        public void RemoveEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }
    }
}