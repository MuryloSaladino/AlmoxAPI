namespace Almox.Application.Features.Categories.Find;

public sealed record FindCategoriesResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    string Description
);