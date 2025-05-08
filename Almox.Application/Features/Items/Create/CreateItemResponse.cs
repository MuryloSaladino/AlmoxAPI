namespace Almox.Application.Features.Items.Create;

public sealed record CreateItemResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity
);