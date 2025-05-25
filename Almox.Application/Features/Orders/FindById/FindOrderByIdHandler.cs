using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository.Orders;
using Almox.Domain.Common.Messages;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Orders.FindById;

public class FindOrderByIdHandler(
    IOrdersRepository ordersRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<FindOrderByIdRequest, FindOrderByIdResponse>
{   
    public async Task<FindOrderByIdResponse> Handle(
        FindOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        var order = await ordersRepository.GetWithItems(request.Id, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Order);

        if(!session.IsAdmin && order.UserId != session.UserId)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        return mapper.Map<FindOrderByIdResponse>(order);
    }
}