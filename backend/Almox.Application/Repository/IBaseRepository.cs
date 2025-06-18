using Almox.Domain.Entities;

namespace Almox.Application.Repository;

public interface IBaseRepository<TEntity, TFilters>
    where TEntity : BaseEntity
    where TFilters : PaginatedFilter
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> Count(CancellationToken cancellationToken);
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> Get(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
    Task<List<TEntity>> GetAll(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    Task<PaginatedResult<TEntity>> GetAll(TFilters filters, CancellationToken cancellationToken);
}

public interface IBaseRepository<TEntity> 
    : IBaseRepository<TEntity, PaginatedFilter>
        where TEntity : BaseEntity;