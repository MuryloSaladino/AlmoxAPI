using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.OrdersRepository;
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
    private readonly IOrderItemsRepository orderItemsRepository = orderItemsRepository;
    private readonly IOrdersRepository ordersRepository = ordersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<AddItemToOrderResponse> Handle(
        AddItemToOrderRequest request, CancellationToken cancellationToken)
    {
        var order = await ordersRepository.Get(request.OrderId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        var session = requestSession.GetSessionOrThrow();

        if(session.UserId != order.UserId && !session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        var orderItem = mapper.Map<OrderItem>(request);
        
        orderItemsRepository.Create(orderItem);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AddItemToOrderResponse>(orderItem);
    }
}