using Almox.Application.Common.Session;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Enums;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.GetAll;

public class GetAllOrdersHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllOrdersRequest, List<GetAllOrdersResponse>>
{
    public async Task<List<GetAllOrdersResponse>> Handle(
        GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var orders = session.Role switch
        {
            UserRole.Employee => await ordersRepository.GetAllByUser(
                session.UserId, request, cancellationToken),
                
            _ => await ordersRepository.GetAll(request, cancellationToken),
        };

        return mapper.Map<List<GetAllOrdersResponse>>(orders);
    }
}