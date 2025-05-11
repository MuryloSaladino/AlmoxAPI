namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestResponse(
    Guid RequestId,
    Guid ItemId,
    int Quantity
);