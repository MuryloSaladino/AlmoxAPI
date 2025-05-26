using Microsoft.EntityFrameworkCore;
using Almox.Persistence.Context;
using Almox.Application.Repository;
using Almox.Domain.Entities;

namespace Almox.Persistence.Repository;

public class BaseRepository<TEntity>(AlmoxContext AlmoxContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AlmoxContext context = AlmoxContext;

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
    
    public virtual Task<List<TEntity>> GetAll(List<Guid> ids, CancellationToken cancellationToken)
        => context.Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .Where(entity => ids.Contains(entity.Id))
            .ToListAsync(cancellationToken);
    
    public virtual Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => context.Set<TEntity>()
            .AnyAsync(e =>
                EF.Property<Guid>(e, "Id") == id &&
                EF.Property<Guid?>(e, "DeletedAt") == null,
            cancellationToken);
}