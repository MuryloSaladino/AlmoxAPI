namespace Almox.Application.Features.Users.Register;

public sealed record RegisterUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    Guid DepartmentId,
    string Username,
    string Email,
    bool IsAdmin
);