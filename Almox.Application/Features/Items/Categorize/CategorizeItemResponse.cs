namespace Almox.Application.Features.Items.Categorize;

public sealed record CategorizeItemResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity,
    string? ImageUrl,
    List<CategorizeItemCategoryPresenter> Categories
);

public sealed record CategorizeItemCategoryPresenter(
    Guid Id,
    string Name,
    string Description,
    string Color
);