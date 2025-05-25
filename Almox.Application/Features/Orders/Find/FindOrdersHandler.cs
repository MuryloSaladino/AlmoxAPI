using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.Find;

public class FindOrdersHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindOrdersRequest, List<FindOrdersResponse>>
{
    public async Task<List<FindOrdersResponse>> Handle(
        FindOrdersRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if(!session.IsAdmin && request.Filters.UserId != session.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var orders = await ordersRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindOrdersResponse>>(orders);
    }
}