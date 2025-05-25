namespace Almox.Application.Features.Categories.GetAll;

public sealed record GetAllCategoriesResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    string Description,
    string Color
);