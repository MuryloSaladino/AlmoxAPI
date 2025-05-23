using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.OrdersRepository;
using Almox.Domain.Common.Messages;
using MediatR;

namespace Almox.Application.Features.Orders.RemoveItem;

public class RemoveItemToOrderHandler(
    IOrderItemsRepository orderItemsRepository,
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<RemoveItemToOrderRequest, RemoveItemToOrderResponse>
{
    public async Task<RemoveItemToOrderResponse> Handle(
        RemoveItemToOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetUserDraftOrder(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if(session.UserId != order.UserId && !session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUserNorAdmin);

        orderItemsRepository.Delete(request.ItemId, order.Id);

        await unitOfWork.Save(cancellationToken);

        return new RemoveItemToOrderResponse();
    }
}