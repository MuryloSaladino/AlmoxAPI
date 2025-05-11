using Almox.Domain.Entities;

namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestResponse(
    Guid RequestId,
    Item Item,
    int Quantity
);