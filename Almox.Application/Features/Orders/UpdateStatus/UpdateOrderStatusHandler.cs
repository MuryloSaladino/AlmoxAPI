using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.OrdersRepository;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using Almox.Domain.Objects;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.UpdateStatus;

public class UpdateOrderStatusHandler(
    IOrderHistoryRepository historyRepository,
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateOrderStatusRequest, UpdateOrderStatusResponse>
{
    private readonly IOrderHistoryRepository historyRepository = historyRepository;
    private readonly IOrdersRepository ordersRepository = ordersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateOrderStatusResponse> Handle(
        UpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Order);

        ValidateOrThrow(request.Status, order, session);

        ApplyChanges(order, request.Status);
        
        SaveHistory(session.UserId, order, request.Status);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateOrderStatusResponse>(order);
    }

    private static void ValidateOrThrow(OrderStatus status, Order order, SessionData session)
    {
        switch (status)
        {
            case OrderStatus.Draft:
                throw new ConflictException(ExceptionMessages.Conflict.ResourceState);

            case OrderStatus.Requested:
                if (order.UserId != session.UserId)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.NotOwnUser);
                break;

            case OrderStatus.Accepted:
            case OrderStatus.Ready:
            case OrderStatus.Completed:
                if (!session.IsAdmin)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);
                break;

            case OrderStatus.Canceled:
                if (!session.IsAdmin && order.UserId != session.UserId)
                    throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);
                break;
        }
    }

    private static void ApplyChanges(Order order, OrderStatus status)
    {
        switch (status)
        {
            case OrderStatus.Completed:
                foreach (var requestItem in order.OrderItems)
                    requestItem.Item.Quantity -= requestItem.FulfilledQuantity;
                break;
            default:
                break;
        }
        order.Status = status;
    }

    private void SaveHistory(Guid userId, Order order, OrderStatus status)
    {
        var history = new OrderHistory()
        {
            OrderId = order.Id,
            Order = order,
            UpdatedById = userId,
            UpdatedBy = null!,
            Status = status,
        };
        historyRepository.Create(history);
    }
}