using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestRequest(
    Guid RequestId,
    Guid ItemId,
    AddItemToRequestRequestBody Body
) : IRequest<AddItemToRequestResponse>;

public sealed record AddItemToRequestRequestBody(
    int Quantity
);