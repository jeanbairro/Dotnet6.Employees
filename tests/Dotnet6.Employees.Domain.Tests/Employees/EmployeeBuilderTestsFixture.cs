using Bogus;
using Dotnet6.Employees.Domain.AggregatesModel.Employees;
using Xunit;

namespace Dotnet6.Employees.Domain.Tests.Employees
{
    [CollectionDefinition(nameof(EmployeeBuilderTestsCollection))]
    public class EmployeeBuilderTestsCollection : ICollectionFixture<EmployeeBuilderTestsFixture>
    {
    }

    public class EmployeeBuilderTestsFixture
    {
        private const float EmptyWeight = .3f;
        private const float NullWeight = .3f;
        private const short PhoneNumbersCount = 3;

        public Employee GetInvalidEmployee()
        {
            var employeeBuilder = new Faker<EmployeeBuilder>()
                .CustomInstantiator(f =>
                    new EmployeeBuilder()
                    .WithEmail(f.Random.AlphaNumeric(Employee.EmailMaxLength + 1).OrNull(f, NullWeight).OrDefault(f, EmptyWeight))
                    .WithFullName(f.Random.AlphaNumeric(Employee.FullNameMaxLength + 1).OrNull(f, NullWeight).OrDefault(f, EmptyWeight))
                    .WithPassword(f.Random.AlphaNumeric(Employee.PasswordMaxLength + 1).OrNull(f, NullWeight).OrDefault(f, EmptyWeight))
                    .WithPhoneNumbers(f
                        .Make(PhoneNumbersCount, () => f.Phone.PhoneNumber("(###)###-###").OrNull(f, NullWeight).OrDefault(f, EmptyWeight)))
                    .WithPlateNumber(f.Random.Number(Employee.PlateNumberMaxSize + 1, int.MaxValue).OrDefault(f, EmptyWeight)));

            return employeeBuilder.Generate().Build();
        }

        public Employee GetValidEmployee()
        {
            var employeeBuilder = new Faker<EmployeeBuilder>()
                .CustomInstantiator(f =>
                    new EmployeeBuilder()
                    .WithEmail(f.Internet.Email())
                    .WithFullName(f.Name.FullName())
                    .WithPassword(f.Internet.Password(Employee.PasswordMaxLength))
                    .WithPhoneNumbers(f.Make(PhoneNumbersCount, () => f.Phone.PhoneNumber("(##)#####-####")))
                    .WithPlateNumber(f.Random.Number(1, Employee.PlateNumberMaxSize)));

            return employeeBuilder.Generate().Build();
        }
    }
}