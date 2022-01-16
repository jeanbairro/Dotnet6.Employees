using Dotnet6.Employees.Domain.Abstractions;
using Dotnet6.Extensions.Strings;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet6.Employees.Domain.Entities.AggregatesModel
{
    public class Employee : ValidableEntity
    {
        public const int EmailMaxLength = 256;
        public const int FullNameMaxLength = 100;
        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 8;
        public const int PlateNumberLength = 8;
        private readonly List<string> _phoneNumbers;

        public Employee(string email, string fullName, string password, ICollection<string> phoneNumbers, string plateNumber)
        {
            _phoneNumbers ??= new List<string>();
            AddPhoneNumbers(phoneNumbers);
            SetEmail(email);
            SetFullName(fullName);
            SetPassword(password);
            SetPlateNumber(plateNumber);
        }

        public string Email { get; private set; }
        public string FullName { get; private set; }
        public long Id { get; set; }
        public string Password { get; set; }
        public IReadOnlyCollection<string> PhoneNumbers => _phoneNumbers;
        public string PlateNumber { get; private set; }

        public void AddPhoneNumbers(ICollection<string> phoneNumbers)
        {
            phoneNumbers?
                .ToList()
                .ForEach(p => AddPhoneNumber(p));
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

        public void SetPlateNumber(string plateNumber)
        {
            if (string.IsNullOrWhiteSpace(plateNumber))
            {
                AddError($"O número de chapa é obrigatório.");
                return;
            }

            if (plateNumber.Length != PlateNumberLength)
            {
                AddError($"Informe o número de chapa com {PlateNumberLength} caracteres.");
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