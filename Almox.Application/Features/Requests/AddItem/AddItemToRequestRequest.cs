using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestRequest(
    Guid RequestId,
    Guid ItemId,
    int Quantity
) : IRequest<AddItemToRequestResponse>;
