using Almox.Domain.Entities;

namespace Almox.Application.Features.Departments.FindById;

public sealed record FindDepartmentByIdResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    List<FindDepartmentByIdResponseUser> Users,
    string Name
);

public record FindDepartmentByIdResponseUser(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);