using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dotnet6.Employees.Domain.AggregatesModel.Employees;

namespace Dotnet6.Employees.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken);
    Task<int> UpdateAsync(Employee employee, CancellationToken cancellationToken);
    Task<int> RemoveAsync(long empployeeId, CancellationToken cancellationToken);
    Task<ICollection<Employee>> ListAllAsync(CancellationToken cancellationToken);
}