using MediatR;

namespace Almox.Application.Features.Items.Create;

public sealed record CreateItemRequest(
    string Name
) : IRequest<CreateItemResponse>;