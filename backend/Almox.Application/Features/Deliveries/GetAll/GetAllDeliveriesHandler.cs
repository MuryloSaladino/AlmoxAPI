using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.GetAll;

public class GetAllDeliveriesHandler(
    IDeliveriesRepository deliveriesRepository,
    IMapper mapper
) : IRequestHandler<GetAllDeliveriesRequest, PaginatedResult<GetAllDeliveriesResponse>>
{
    public async Task<PaginatedResult<GetAllDeliveriesResponse>> Handle(
        GetAllDeliveriesRequest request, CancellationToken cancellationToken)
    {
        var deliveries = await deliveriesRepository.GetAll(request, cancellationToken);

        return mapper.Map<PaginatedResult<GetAllDeliveriesResponse>>(deliveries);
    }
}