using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet6.Employees.Domain.AggregatesModel.Employees;

namespace Dotnet6.Employees.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> AddAsync(Employee employee);
    Task<int> UpdateAsync(Employee employee);
    Task<int> RemoveAsync(long empployeeId);
    Task<ICollection<Employee>> ListAllAsync();
}