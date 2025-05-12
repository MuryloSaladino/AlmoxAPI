using Almox.Domain.Entities;

namespace Almox.Application.Repository.RequestsRepository;

public interface IRequestsRepository : IBaseRepository<Request> 
{
    Task<List<Request>> GetWithFilters(RequestsQueryFilters filters, CancellationToken cancellationToken);
}