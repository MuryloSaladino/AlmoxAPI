using Almox.Application.Common.Generators;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Orders;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Start;

public class StartOrderHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<StartOrderRequest, StartOrderResponse>
{
    public async Task<StartOrderResponse> Handle(
        StartOrderRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetUserCartOrder(session.UserId, cancellationToken);

        if(order is null)
        {
            order = new()
            {
                Tracking = TrackingCodeGenerator.Generate(),
                UserId = session.UserId
            };
            ordersRepository.Create(order);

            await unitOfWork.Save(cancellationToken);
        }

        return mapper.Map<StartOrderResponse>(order);
    }
}