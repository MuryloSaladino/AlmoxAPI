using Almox.Domain.Common.Enums;
using MediatR;

namespace Almox.Application.Features.Orders.GetAll;

public sealed record GetAllOrdersRequest(
    OrderStatus? Status
) : IRequest<List<GetAllOrdersResponse>>;