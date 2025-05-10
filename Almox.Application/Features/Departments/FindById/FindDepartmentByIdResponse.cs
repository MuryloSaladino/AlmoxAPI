using Almox.Domain.Entities;

namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    List<User> Users,
    string Name
);