using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.Find;

public sealed record FindUserResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin,
    List<Skill> Almox
);