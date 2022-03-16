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
        
        public void CreateEmployee(string name, string email, string phoneNr)
        {
            var id = 0; //todo replace this placeholder with id from database response
            var employeeNr = ""; //todo replace this placeholder with id from database response encrypted to string
            var employee = new Employee();
            employee.SetName(name);
            employee.SetEmail(email);
            employee.SetPhoneNr(phoneNr);
            _employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }
    }
}