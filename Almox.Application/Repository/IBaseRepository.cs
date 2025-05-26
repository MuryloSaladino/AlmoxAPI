using Almox.Domain.Entities;

namespace Almox.Application.Repository;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> Get(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
    Task<List<TEntity>> GetAll(List<Guid> ids, CancellationToken cancellationToken);
}

public interface IBaseRepository<TEntity, TFilters> 
    : IBaseRepository<TEntity>
        where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAll(TFilters filters, CancellationToken cancellationToken);
}