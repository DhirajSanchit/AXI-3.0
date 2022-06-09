using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;

namespace AxiUnitTests.Scrubs // to do
{
    public class EmployeeMock : IEmployeeDAL
    {
        private IDalFactory mockdalfactory;
        public List<EmployeeDto> employees = new List<EmployeeDto>();

        public EmployeeMock(IDalFactory dalFactory)
        {
            mockdalfactory = dalFactory;
            var employee1 = new EmployeeDto()
            {
                Id = 1,
                Email = "Test@gmail.com",
                Name = "Name1",
                Description = "Placeholder",
                EmployeeNr = "A1042",
                PhoneNr = "+3168912341",
            }; 
            var employee2 = new EmployeeDto()
            {
                Id = 2,
                Email = "Testemployee@gmail.com",
                Name = "Name2",
                Description = "Placeholders",
                EmployeeNr = "A1044",
                PhoneNr = "+3168915748",
            };
            employees.Add(employee1);
            employees.Add(employee2);
        }

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