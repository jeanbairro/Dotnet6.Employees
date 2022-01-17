using Dotnet6.Employees.Data.Repositories.Abstractions;
using Dotnet6.Employees.Domain.AggregatesModel.Employees;
using Dotnet6.Employees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.Employees.Data.Repositories.Employees;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DbContext context) 
        : base(context)
    {
    }
}