using Almox.Application.Common.Generators;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.Create;

public class CreateDeliveryHandler(
    IDeliveryStatusUpdatesRepository statusUpdatesRepository,
    IDeliveriesRepository deliveriesRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateDeliveryRequest, CreateDeliveryResponse>
{
    public async Task<CreateDeliveryResponse> Handle(
        CreateDeliveryRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetStaffSessionOrThrow();

        var delivery = mapper.Map<Delivery>(request);
        delivery.Tracking = TrackingCodeGenerator.Generate();

        deliveriesRepository.Create(delivery);

        statusUpdatesRepository.Create(new()
        {
            DeliveryId = delivery.Id,
            UpdatedById = session.UserId,
            Status = delivery.Status
        });

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateDeliveryResponse>(delivery);
    }
}