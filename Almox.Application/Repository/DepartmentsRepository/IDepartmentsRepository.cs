using Almox.Domain.Entities;

namespace Almox.Application.Repository.DepartmentsRepository;

public interface IDepartmentRepository : IBaseRepository<Department> 
{
    Task<List<Department>> GetByName(string? name, CancellationToken cancellationToken);
    Task<Department?> GetWithUsers(Guid id, CancellationToken cancellationToken);
}