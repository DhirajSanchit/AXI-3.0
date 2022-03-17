namespace AxiLogic.Classes
{
    public class Employee
    { 
        public string EmployeeNr { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNr { get; private set; }
        public int Id { get; private set; }

        public Employee(string name, string email)
        { 
            Email = email;
            Name = name;
        }
        
        public void SetName(string name)
        {
            Name = name;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
        
        public void SetPhoneNr(string phoneNr)
        {
            PhoneNr = phoneNr;
        }
    }
}