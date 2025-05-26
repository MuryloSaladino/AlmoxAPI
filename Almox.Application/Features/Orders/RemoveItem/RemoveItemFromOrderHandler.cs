using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Exceptions;
using MediatR;

namespace Almox.Application.Features.Orders.RemoveItem;

public class RemoveItemFromOrderHandler(
    IOrderItemsRepository orderItemsRepository,
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<RemoveItemFromOrderRequest, RemoveItemFromOrderResponse>
{
    public async Task<RemoveItemFromOrderResponse> Handle(
        RemoveItemFromOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetUserCartOrder(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if(session.UserId != order.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUser);

        orderItemsRepository.Delete(request.ItemId, order.Id);

        await unitOfWork.Save(cancellationToken);

        return new RemoveItemFromOrderResponse();
    }
}