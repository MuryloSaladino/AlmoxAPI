using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Exceptions;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.AddItem;

public class AddItemToOrderHandler(
    IOrderItemsRepository orderItemsRepository,
    IOrdersRepository ordersRepository,
    IItemsRepository itemsRepository,
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
            
        var item = await itemsRepository.Get(request.ItemId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Item);

        var orderItem = await orderItemsRepository.Get(request.ItemId, order.Id, cancellationToken);

        if (orderItem is null)
        {
            orderItem = mapper.Map<OrderItem>(request);
            orderItem.OrderId = order.Id;
            orderItemsRepository.Create(orderItem);
        }
        orderItem.Quantity = request.Quantity;
        orderItem.Price = item.Price;

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AddItemToOrderResponse>(orderItem);
    }
}