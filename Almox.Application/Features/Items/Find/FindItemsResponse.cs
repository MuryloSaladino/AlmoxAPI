namespace Almox.Application.Features.Items.Find;

public sealed record FindItemsResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity
);