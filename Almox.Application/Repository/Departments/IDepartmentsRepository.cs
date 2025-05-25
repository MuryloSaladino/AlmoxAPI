using Almox.Domain.Entities;

namespace Almox.Application.Repository.Departments;

public record DepartmentFilters(
    string? Name
);

public interface IDepartmentRepository
    : IBaseRepository<Department, DepartmentFilters>;