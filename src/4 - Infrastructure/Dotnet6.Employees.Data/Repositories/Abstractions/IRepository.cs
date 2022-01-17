using Dotnet6.Employees.Domain.Abstractions;

namespace Dotnet6.Employees.Data.Repositories.Abstractions;

public interface IRepository<T> where T : Entity
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<int> RemoveAsync(long id, CancellationToken cancellationToken);
    Task<ICollection<T>> ListAllAsync(CancellationToken cancellationToken);
}