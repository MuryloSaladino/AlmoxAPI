using Almox.Domain.Entities;

namespace Almox.Application.Repository.Departments;

public interface IDepartmentRepository : IBaseRepository<Department> 
{
    Task<List<Department>> GetWithFilters(
        DepartmentsQueryFilters filters, CancellationToken cancellationToken);
    Task<Department?> GetWithUsers(Guid id, CancellationToken cancellationToken);
}