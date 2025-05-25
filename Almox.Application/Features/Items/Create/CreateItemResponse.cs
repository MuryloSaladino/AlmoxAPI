using Almox.Domain.Entities;

namespace Almox.Application.Features.Items.Create;

public sealed record CreateItemResponse(
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