namespace Almox.Application.Features.Almox.Edit;

public sealed record EditSkillResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    int Level
);