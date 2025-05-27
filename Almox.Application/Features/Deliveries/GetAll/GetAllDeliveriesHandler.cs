using Almox.Application.Common.Session;
using Almox.Application.Repository.Deliveries;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.GetAll;

public class GetAllDeliveriesHandler(
    IDeliveriesRepository deliveriesRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllDeliveriesRequest, List<GetAllDeliveriesResponse>>
{
    public async Task<List<GetAllDeliveriesResponse>> Handle(
        GetAllDeliveriesRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetStaffSessionOrThrow();

        var deliveries = await deliveriesRepository.GetAll(request, cancellationToken);

        return mapper.Map<List<GetAllDeliveriesResponse>>(deliveries);
    }
}