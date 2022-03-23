using AxiInterfaces.DTOs;

namespace AxiInterfaces.Interfaces
{
    public interface IEmployee
    {
        void AddEmployee(EmployeeDto employeeDto);

        void RemoveEmployee(EmployeeDto employeeDto);
    }
}