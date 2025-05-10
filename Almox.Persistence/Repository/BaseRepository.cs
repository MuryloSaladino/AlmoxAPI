using Microsoft.EntityFrameworkCore;
using Almox.Persistence.Context;
using Almox.Application.Repository;
using Almox.Domain.Entities;

namespace Almox.Persistence.Repository;

public class BaseRepository<TEntity>(AlmoxContext AlmoxContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AlmoxContext context = AlmoxContext;
    protected readonly DbSet<TEntity> dbSet = AlmoxContext.Set<TEntity>();

    public void Create(TEntity entity)
        => context.Add(entity);

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        context.Update(entity);
    }

    public Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        => context
            .Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        => context
            .Set<TEntity>()
            .Where(entity => entity.DeletedAt == null)
            .ToListAsync(cancellationToken);

    public void Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        context.Update(entity);
    }
    
    public Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => dbSet.AnyAsync(e => 
            EF.Property<Guid>(e, "Id") == id && 
            EF.Property<Guid?>(e, "DeletedAt") == null, 
        cancellationToken);
}