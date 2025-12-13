using Microsoft.EntityFrameworkCore;
using Redarbor.Domain.Services.Persistence;
using System.Linq.Expressions;

namespace Redarbor.InfrastructureEF.Persistence.Repository;

public abstract class RepositoryBase<T>(DbContext dbContext) : IRepositoryBase<T> where T : class
{
    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().Add(entity);
        await SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().AddRange(entities);
        await SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    => await FindByCondition(expression).Result.AnyAsync(cancellationToken);

    public IAsyncEnumerable<T> AsAsyncEnumerable(Expression<Func<T, bool>> expression)
    => FindByCondition(expression).Result.AsAsyncEnumerable();

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().Remove(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().RemoveRange(entities);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    => await FindByCondition(expression).Result.FirstOrDefaultAsync(cancellationToken);

    public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    => await dbContext.Set<T>().FindAsync([id], cancellationToken: cancellationToken);

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    => await dbContext.Set<T>().ToListAsync(cancellationToken);

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    => await FindByCondition(expression).Result.ToListAsync(cancellationToken);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    => await dbContext.SaveChangesAsync(cancellationToken);

    public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    => await FindByCondition(expression).Result.SingleOrDefaultAsync(cancellationToken);

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().Update(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        dbContext.Set<T>().UpdateRange(entities);
        await SaveChangesAsync(cancellationToken);
    }

    protected async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
    => await Task.FromResult(dbContext.Set<T>().Where(expression).AsNoTracking());
}
