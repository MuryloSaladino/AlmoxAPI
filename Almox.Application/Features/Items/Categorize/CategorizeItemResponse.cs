using Almox.Domain.Entities;

namespace Almox.Application.Features.Items.Categorize;

public sealed record CategorizeItemResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity,
    List<CategorizeItemResponseCategory> Categories
);

public sealed record CategorizeItemResponseCategory(
    Guid Id,
    string Name
);