using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Users.GetAll;

public sealed record GetAllUsersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    UserRole Role,
    string DepartmentName,
    Guid DepartmentId
);
