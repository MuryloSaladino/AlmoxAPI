using MediatR;

namespace Almox.Application.Features.Requests.AddItem;

public sealed record AddItemToRequestRequest(
    string ItemId,
    string RequestId,
    int Quantity
) : IRequest<AddItemToRequestResponse>;
