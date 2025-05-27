using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.Cancel;

public class CancelDeliveryHandler(
    IDeliveriesRepository deliveriesRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CancelDeliveryRequest, CancelDeliveryResponse>
{
    public async Task<CancelDeliveryResponse> Handle(
        CancelDeliveryRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetStaffSessionOrThrow();

        var delivery = await deliveriesRepository.Get(request.DeliveryId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Delivery);

        if (delivery.Status.Equals(DeliveryStatus.Received) || delivery.Status.Equals(DeliveryStatus.Canceled))
            throw AppException.Conflict(ExceptionMessages.Conflict.ResourceState);

        delivery.Status = DeliveryStatus.Canceled;

        delivery.StatusUpdates.Add(new()
        {
            DeliveryId = delivery.Id,
            Status = delivery.Status,
            UpdatedById = session.UserId,
            Observations = request.Observations,
        });
        deliveriesRepository.Update(delivery);
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CancelDeliveryResponse>(delivery);
    }
}