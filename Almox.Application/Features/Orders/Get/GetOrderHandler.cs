using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Get;

public class GetOrderHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetOrderRequest, GetOrderResponse>
{   
    public async Task<GetOrderResponse> Handle(
        GetOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.Get(request.OrderId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if(session.Role.Equals(UserRole.Employee) && order.UserId != session.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        return mapper.Map<GetOrderResponse>(order);
    }
}