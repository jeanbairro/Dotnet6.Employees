using System.Collections.Generic;
using System.Linq;
using Dotnet6.Employees.Domain.Abstractions;
using Dotnet6.Employees.Extensions.Strings;

namespace Dotnet6.Employees.Domain.AggregatesModel.Employees
{
    public class Employee : Entity
    {
        public const int EmailMaxLength = 256;
        public const int FullNameMaxLength = 100;
        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 8;
        public const int PlateNumberMaxSize = 99999999;
        private readonly List<string> _phoneNumbers;

        public Employee(string email, string fullName, string password, ICollection<string> phoneNumbers, int plateNumber)
        {
            _phoneNumbers = new List<string>();
            AddPhoneNumbers(phoneNumbers);
            SetEmail(email);
            SetFullName(fullName);
            SetPassword(password);
            SetPlateNumber(plateNumber);
        }

        public string Email { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public IReadOnlyCollection<string> PhoneNumbers => _phoneNumbers;
        public int PlateNumber { get; private set; }

        public void AddPhoneNumbers(ICollection<string> phoneNumbers)
        {
            phoneNumbers?
                .ToList()
                .ForEach(AddPhoneNumber);
        }

        public void SetEmail(string email)
        {
            if (!email.IsEmail())
            {
                AddError($"Informe um e-mail válido.");
                return;
            }

            if (email.Length > EmailMaxLength)
            {
                AddError($"Informe o e-mail com no máximo {EmailMaxLength} caracteres.");
                return;
            }

            Email = email;
        }

        public void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                AddError("O nome completo é obrigatório.");
                return;
            }

            if (fullName.Length > FullNameMaxLength)
            {
                AddError($"Informe o nome completo com no máximo {FullNameMaxLength} caracteres.");
                return;
            }

            FullName = fullName;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                AddError("A senha é obrigatória");
                return;
            }

            if (password.Length < PasswordMinLength || password.Length > PasswordMaxLength)
            {
                AddError($"Informe uma senha entre {PasswordMinLength} e {PasswordMaxLength} caracteres.");
                return;
            }

            Password = password;
        }

        public void SetPlateNumber(int plateNumber)
        {
            if (plateNumber == default)
            {
                AddError($"O número de chapa é obrigatório.");
                return;
            }

            if (plateNumber > PlateNumberMaxSize)
            {
                AddError($"O número de chapa deve ser menor que {PlateNumberMaxSize}.");
                return;
            }

            PlateNumber = plateNumber;
        }

        private void AddPhoneNumber(string phoneNumber)
        {
            if (!phoneNumber.IsPhoneNumber())
            {
                AddError($"O número de telefone {phoneNumber} é inválido.");
                return;
            }

            _phoneNumbers.Add(phoneNumber);
        }
    }
}