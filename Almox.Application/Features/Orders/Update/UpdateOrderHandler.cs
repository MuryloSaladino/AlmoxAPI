using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.OrdersRepository;
using Almox.Domain.Common.Messages;
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
    private readonly IOrdersRepository ordersRepository = ordersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateOrderResponse> Handle(
        UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Order);

        if(session.UserId != order.UserId)
            throw new ForbiddenException(ExceptionMessages.Forbidden.NotOwnUser);

        order.Priority = request.Props.Priority;
        order.Observations = request.Props.Observations;

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateOrderResponse>(order);
    }
}