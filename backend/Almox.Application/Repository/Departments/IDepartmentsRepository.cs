using Almox.Domain.Entities;

namespace Almox.Application.Repository.Departments;

public record DepartmentFilters : PaginatedFilter
{
    public string? Name { get; init; }
}

public interface IDepartmentsRepository
    : IBaseRepository<Department, DepartmentFilters>;