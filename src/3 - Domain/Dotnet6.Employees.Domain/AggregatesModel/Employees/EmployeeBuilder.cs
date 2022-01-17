using System.Collections.Generic;

namespace Dotnet6.Employees.Domain.AggregatesModel.Employees
{
    public class EmployeeBuilder
    {
        private string email;
        private string fullName;
        private string password;
        private ICollection<string> phoneNumbers;
        private int plateNumber;
        
        public Employee Build()
            => new(email, fullName, password, phoneNumbers, plateNumber);

        public EmployeeBuilder WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public EmployeeBuilder WithFullName(string fullName)
        {
            this.fullName = fullName;
            return this;
        }
        public EmployeeBuilder WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public EmployeeBuilder WithPhoneNumbers(ICollection<string> phoneNumbers)
        {
            this.phoneNumbers = phoneNumbers;
            return this;
        }

        public EmployeeBuilder WithPlateNumber(int plateNumber)
        {
            this.plateNumber = plateNumber;
            return this;
        }
    }
}
