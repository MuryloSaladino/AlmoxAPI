using MediatR;

namespace Almox.Application.Features.Orders.FindById;

public sealed record FindOrderByIdRequest(
    Guid Id
) : IRequest<FindOrderByIdResponse>;