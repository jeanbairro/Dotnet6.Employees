using Dotnet6.Employees.Domain.AggregatesModel.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnet6.Employees.Data.Configs;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).HasMaxLength(Employee.EmailMaxLength).IsRequired();
        builder.Property(x => x.FullName).HasMaxLength(Employee.FullNameMaxLength).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(Employee.PasswordMaxLength).IsRequired();
        builder.Property(x => x.PlateNumber).IsRequired();
        builder.HasIndex(x => x.Id);
    }
}