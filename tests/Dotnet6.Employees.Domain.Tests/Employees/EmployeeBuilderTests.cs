using Xunit;

namespace Dotnet6.Employees.Domain.Tests.Employees
{
    [Collection(nameof(EmployeeBuilderTestsCollection))]
    public class EmployeeBuilderTests
    {
        private const short ErrorsCount = 7;

        public EmployeeBuilderTests(EmployeeBuilderTestsFixture fixture)
        {
            Fixture = fixture;
        }

        public EmployeeBuilderTestsFixture Fixture { get; set; }

        [Fact(DisplayName = "Deve criar um funcionário inválido")]
        public void ShouldBuildAnInvalidEmployee()
        {
            var employee = Fixture.GetInvalidEmployee();
            Assert.NotNull(employee);
            Assert.False(employee.IsValid());
            Assert.NotEmpty(employee.GetErrors());
            Assert.Equal(ErrorsCount, employee.GetErrors().Count);
        }

        [Fact(DisplayName = "Deve criar um funcionário válido")]
        public void ShouldBuildAnValidEmployee()
        {
            var employee = Fixture.GetValidEmployee();
            Assert.NotNull(employee);
            Assert.Empty(employee.GetErrors());
            Assert.True(employee.IsValid());
        }
    }
}
