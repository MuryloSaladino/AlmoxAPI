using Almox.Domain.Entities;

namespace Almox.Application.Features.Items.UpdateImage;

public sealed record UpdateImageItemResponse(
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