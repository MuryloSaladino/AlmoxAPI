namespace Almox.Application.Features.Users.Find;

public sealed record FindUsersResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid DepartmentId,
    string Username,
    string Email,
    bool IsAdmin
);
