namespace Almox.Application.Features.Items.UpdateImage;

public sealed record UpdateImageItemResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity,
    string ImageUrl
);