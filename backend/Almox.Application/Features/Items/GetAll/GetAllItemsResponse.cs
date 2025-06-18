using Almox.Domain.Entities;

namespace Almox.Application.Features.Items.GetAll;

public sealed record GetAllItemsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string? ImageUrl,
    List<Category> Categories
);