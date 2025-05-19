using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.OrdersRepository;
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
    private readonly IOrdersRepository ordersRepository = ordersRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindOrdersResponse>> Handle(
        FindOrdersRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if(!session.IsAdmin && request.Filters.UserId != session.UserId)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var orders = await ordersRepository.GetWithFilters(request.Filters, cancellationToken);

        return mapper.Map<List<FindOrdersResponse>>(orders);
    }
}