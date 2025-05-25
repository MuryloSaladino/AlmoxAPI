using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.AddItem;

public class AddItemToOrderHandler(
    IOrderItemsRepository orderItemsRepository,
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AddItemToOrderRequest, AddItemToOrderResponse>
{
    public async Task<AddItemToOrderResponse> Handle(
        AddItemToOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetUserCartOrder(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if(session.UserId != order.UserId && !session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        var orderItem = await orderItemsRepository.Get(request.ItemId, order.Id, cancellationToken);

        if (orderItem is null)
        {
            orderItem = mapper.Map<OrderItem>(request);
            orderItem.OrderId = order.Id;
            orderItemsRepository.Create(orderItem);
        }
        orderItem.Quantity = request.Props.Quantity;

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AddItemToOrderResponse>(orderItem);
    }
}