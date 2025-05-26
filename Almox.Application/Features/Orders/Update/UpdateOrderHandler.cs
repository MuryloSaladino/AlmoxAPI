using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Update;

public class UpdateOrderHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
{
    public async Task<UpdateOrderResponse> Handle(
        UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.Get(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if(session.UserId != order.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.NotOwnUser);

        order.Priority = request.Priority;
        order.Observations = request.Observations;

        ordersRepository.Update(order);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateOrderResponse>(order);
    }
}