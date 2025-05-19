namespace Almox.Application.Features.Items.Categorize;

public sealed record CategorizeItemResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity,
    List<CategorizeItemCategoryPresenter> Categories
);

public sealed record CategorizeItemCategoryPresenter(
    Guid Id,
    string Name,
    string Description
);