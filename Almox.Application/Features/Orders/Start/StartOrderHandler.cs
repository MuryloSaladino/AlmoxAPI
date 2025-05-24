using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.OrdersRepository;
using Almox.Application.Repository.UsersRepository;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Start;

public class StartOrderHandler(
    IOrderHistoryRepository historyRepository,
    IOrdersRepository ordersRepository,
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<StartOrderRequest, StartOrderResponse>
{
    public async Task<StartOrderResponse> Handle(
        StartOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var user = await usersRepository.Get(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);

        var order = await ordersRepository.GetUserCartOrder(
            session.UserId, cancellationToken);

        if(order is null)
        {
            order = new()
            {
                User = user,
                UserId = user.Id
            };
            ordersRepository.Create(order);

            historyRepository.Create(new()
            {
                Order = order,
                OrderId = order.Id,
                Status = order.Status,
                UpdatedBy = user,
                UpdatedById = user.Id
            });
            
            await unitOfWork.Save(cancellationToken);
        }

        return mapper.Map<StartOrderResponse>(order);
    }
}