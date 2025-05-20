namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity,
    string ImageUrl
);