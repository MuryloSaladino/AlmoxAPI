namespace Almox.Application.Features.Items.Update;

public sealed record UpdateItemResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity
);