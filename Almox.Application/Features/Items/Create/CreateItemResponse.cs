namespace Almox.Application.Features.Items.Create;

public sealed record CreateItemResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name, 
    int Quantity
);