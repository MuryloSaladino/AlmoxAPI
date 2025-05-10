namespace Almox.Application.Features.Users.Promote;

public sealed record PromoteUserResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    string Email,
    bool IsAdmin
);