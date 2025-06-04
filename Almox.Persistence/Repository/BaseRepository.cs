using Microsoft.EntityFrameworkCore;
using Almox.Persistence.Context;
using Almox.Application.Repository;
using Almox.Domain.Entities;

namespace Almox.Persistence.Repository;

public class BaseRepository<TEntity>(
    AlmoxContext context
) : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AlmoxContext context = context;

    public void Create(TEntity entity)
        => context.Add(entity);

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        context.Update(entity);
    }

    public virtual Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        => context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public virtual Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        => context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .ToListAsync(cancellationToken);

    public virtual Task<List<TEntity>> GetAll(
        IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => context.Set<TEntity>()
                .Where(entity => entity.DeletedAt == null)
                .Where(entity => ids.Contains(entity.Id))
                .ToListAsync(cancellationToken);

    public async Task<PaginatedResult<TEntity>> GetAll(
        PaginatedFilter filters, CancellationToken cancellationToken)
    {
        var query = context.Set<TEntity>()
            .AsQueryable()
            .Where(e => e.DeletedAt == null);

        var count = await query.CountAsync(cancellationToken);
        var maxPage = (int)Math.Ceiling(count / (double)filters.PageSize);

        var results = await query
            .OrderByDescending(e => e.CreatedAt)
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(cancellationToken);

        return new(filters.Page, filters.PageSize, maxPage, results);
    }

    public virtual Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => context.Set<TEntity>()
            .Where(e => e.Id == id)
            .Where(e => e.DeletedAt == null)
            .AnyAsync(cancellationToken);

    public Task<int> Count(CancellationToken cancellationToken)
        => context.Set<TEntity>()
            .Where(e => e.DeletedAt == null)
            .CountAsync(cancellationToken);
}