using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Users.Get;

public sealed record GetUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    UserRole Role,
    string DepartmentName
);