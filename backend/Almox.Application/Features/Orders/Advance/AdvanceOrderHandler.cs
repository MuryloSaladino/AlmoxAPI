using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Advance;

public class AdvanceOrderHandler(
    IOrdersRepository ordersRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AdvanceOrderRequest, AdvanceOrderResponse>
{
    public async Task<AdvanceOrderResponse> Handle(
        AdvanceOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetStaffSessionOrThrow();

        var order = await ordersRepository.Get(request.OrderId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        order.Status = order.Status switch
        {
            OrderStatus.Requested => OrderStatus.Accepted,
            OrderStatus.Accepted => OrderStatus.Ready,
            OrderStatus.Ready => OrderStatus.Completed,
            _ => throw AppException.Conflict(ExceptionMessages.Conflict.ResourceState)
        };

        order.StatusUpdates.Add(new()
        {
            OrderId = order.Id,
            Status = order.Status,
            UpdatedById = session.UserId,
            Observations = request.Observations,
        });
        ordersRepository.Update(order);

        if (order.Status == OrderStatus.Completed)
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.Item.Stock -= orderItem.Quantity;    
                itemsRepository.Update(orderItem.Item);
            }
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AdvanceOrderResponse>(order);
    }
}