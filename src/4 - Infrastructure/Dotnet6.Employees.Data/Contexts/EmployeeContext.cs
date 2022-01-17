using Dotnet6.Employees.Domain.AggregatesModel.Employees;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.Employees.Data.Contexts;

public class EmployeeContext : DbContext, IEmployeeContext
{
    public EmployeeContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Employee>? Employees { get; set; }
}