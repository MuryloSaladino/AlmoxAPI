namespace Almox.Application.Features.Items.Find;

public sealed record FindItemsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity,
    string? ImageUrl,
    List<FindItemsCategoryPresenter> Categories
);

public sealed record FindItemsCategoryPresenter(
    Guid Id,
    string Name,
    string Color
);