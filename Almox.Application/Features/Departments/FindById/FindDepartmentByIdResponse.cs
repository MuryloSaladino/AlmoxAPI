using Almox.Domain.Entities;

namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    List<User> Users,
    string Name
);