namespace Almox.Application.Features.Categories.Create;

public sealed record CreateCategoryResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    string Description,
    string Color
);