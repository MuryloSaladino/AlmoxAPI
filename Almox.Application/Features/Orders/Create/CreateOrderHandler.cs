using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Items;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Exceptions;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Create;

public class CreateOrderHandler(
    IOrderStatusUpdatesRepository updatesRepository,
    IOrdersRepository ordersRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    public async Task<CreateOrderResponse> Handle(
        CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = mapper.Map<Order>(request);
        order.UserId = session.UserId;

        var itemIds = request.OrderedItems.Select(x => x.ItemId);
        var itemsDict = request.OrderedItems.ToDictionary(x => x.ItemId);
        var items = await itemsRepository.GetAll(itemIds, cancellationToken);

        order.OrderItems = [..items.Select(orderItem => new OrderItem
        {
            ItemId = orderItem.Id,
            OrderId = order.Id,
            Price = orderItem.Price,
            Quantity = itemsDict[orderItem.Id].Quantity
        })];

        ordersRepository.Create(order);

        updatesRepository.Create(new()
        {
            OrderId = order.Id,
            Status = order.Status,
            UpdatedById = session.UserId,
            Observations = request.Observations
        });

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateOrderResponse>(order);
    }
}