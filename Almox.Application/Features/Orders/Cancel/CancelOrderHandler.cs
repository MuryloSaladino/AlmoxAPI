using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Cancel;

public class CancelOrderHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CancelOrderRequest, CancelOrderResponse>
{
    public async Task<CancelOrderResponse> Handle(
        CancelOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.Get(request.OrderId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if (session.Role.Equals(UserRole.Employee) && order.UserId != session.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        if (order.Status.Equals(OrderStatus.Completed) || order.Status.Equals(OrderStatus.Canceled))
            throw AppException.Conflict(ExceptionMessages.Conflict.ResourceState);

        order.Status = OrderStatus.Canceled;
        order.StatusUpdates.Add(new()
        {
            OrderId = order.Id,
            Status = order.Status,
            UpdatedById = session.UserId,
            Observations = request.Observations,
        });

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CancelOrderResponse>(order);
    }
}