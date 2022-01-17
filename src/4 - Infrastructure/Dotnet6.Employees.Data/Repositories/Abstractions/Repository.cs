using Dotnet6.Employees.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.Employees.Data.Repositories.Abstractions;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> RemoveAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id,cancellationToken);
        if (entity == null) return default;
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync(cancellationToken);

    }

    public async Task<ICollection<T>> ListAllAsync(CancellationToken cancellationToken)
        => await _dbSet.ToListAsync(cancellationToken);
}