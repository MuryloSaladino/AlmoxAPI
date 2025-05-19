using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestRequest(
    Guid RequestId,
    Guid ItemId,
    AddItemToRequestRequestProps Props
) : IRequest<AddItemToRequestResponse>;

public sealed record AddItemToRequestRequestProps(
    int Quantity
);