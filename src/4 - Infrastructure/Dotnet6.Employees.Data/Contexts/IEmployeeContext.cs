using Dotnet6.Employees.Domain.AggregatesModel.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Dotnet6.Employees.Data.Contexts;

public interface IEmployeeContext
{
    DatabaseFacade Database { get; }

    DbSet<Employee>? Employees { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}