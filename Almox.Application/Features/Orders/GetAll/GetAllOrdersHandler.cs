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

        Guid? userIdFilter = session.Role == UserRole.Employee ? session.UserId : null;
        var filters = new OrderFilters(userIdFilter, request.Status);

        var orders = await ordersRepository.GetAll(filters, cancellationToken);

        return mapper.Map<List<GetAllOrdersResponse>>(orders);
    }
}