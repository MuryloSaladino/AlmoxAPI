using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestRequest(
    Guid ItemId,
    Guid RequestId,
    int Quantity
) : IRequest<AddItemToRequestResponse>;
