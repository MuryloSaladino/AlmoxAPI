namespace Almox.Application.Features.Users.Promote;

public sealed record PromoteUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    Guid DepartmentId,
    string Username,
    string Email,
    bool IsAdmin
);