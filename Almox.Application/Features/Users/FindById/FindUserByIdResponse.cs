namespace Almox.Application.Features.Users.FindById;

public sealed record FindUserByIdResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid DepartmentId,
    string Username,
    string Email,
    bool IsAdmin
);