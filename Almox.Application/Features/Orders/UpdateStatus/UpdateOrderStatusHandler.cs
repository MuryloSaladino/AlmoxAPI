using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using Almox.Domain.Entities;
using Almox.Domain.Objects;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.UpdateStatus;

public class UpdateOrderStatusHandler(
    IOrdersRepository ordersRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateOrderStatusRequest, UpdateOrderStatusResponse>
{
    public async Task<UpdateOrderStatusResponse> Handle(
        UpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.Get(request.OrderId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        ValidateOrThrow(request.Status, order, session);

        order.Status = request.Status;        
        order.StatusUpdates.Add(new()
        {
            UpdatedById = session.UserId,
            OrderId = request.OrderId,
            Status = request.Status,
        });
        ordersRepository.Update(order);

        if (request.Status == OrderStatus.Completed)
            await ApplyStockChanges(order, cancellationToken);
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateOrderStatusResponse>(order);
    }

    private static void ValidateOrThrow(OrderStatus status, Order order, SessionData session)
    {
        switch (status)
        {
            case OrderStatus.Requested:
                if (order.UserId != session.UserId)
                    throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUser);
                break;

            case OrderStatus.Accepted:
            case OrderStatus.Ready:
            case OrderStatus.Completed:
            case OrderStatus.Rejected:
                if (session.Role.Equals(UserRole.Employee))
                    throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);
                break;

            case OrderStatus.Canceled:
                if (session.Role.Equals(UserRole.Employee) && order.UserId != session.UserId)
                    throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);
                break;
        }
    }

    private async Task ApplyStockChanges(Order order, CancellationToken cancellationToken)
    {
        var updateTasks = order.OrderItems.Select(async orderItem =>
        {
            var item = await itemsRepository.Get(orderItem.ItemId, cancellationToken);
            if (item is not null)
            {
                item.Stock -= orderItem.Quantity;
                itemsRepository.Update(item);
            }
        });
        await Task.WhenAll(updateTasks);
    }
}