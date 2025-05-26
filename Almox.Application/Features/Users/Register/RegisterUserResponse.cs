using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Users.Register;

public sealed record RegisterUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    UserRole Role,
    string DepartmentName
);