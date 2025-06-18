using Almox.Domain.Common.Enums;

namespace Almox.Application.Features.Auth.GetLoggedUser;

public sealed record GetLoggedUserResponse(
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