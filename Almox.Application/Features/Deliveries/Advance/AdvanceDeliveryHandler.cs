using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using Almox.Application.Repository.Items;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.Advance;

public class AdvanceDeliveryHandler(
    IDeliveriesRepository deliveriesRepository,
    IItemsRepository itemsRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AdvanceDeliveryRequest, AdvanceDeliveryResponse>
{
    public async Task<AdvanceDeliveryResponse> Handle(
        AdvanceDeliveryRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetStaffSessionOrThrow();

        var delivery = await deliveriesRepository.Get(request.DeliveryId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.Delivery);

        delivery.Status = delivery.Status switch
        {
            DeliveryStatus.Booked => DeliveryStatus.InTransit,
            DeliveryStatus.InTransit => DeliveryStatus.Received,
            _ => throw AppException.Conflict(ExceptionMessages.Conflict.ResourceState)
        };

        delivery.StatusUpdates.Add(new()
        {
            DeliveryId = delivery.Id,
            Status = delivery.Status,
            UpdatedById = session.UserId,
            Observations = request.Observations,
        });
        deliveriesRepository.Update(delivery);

        if (delivery.Status == DeliveryStatus.Received)
            foreach (var deliveryItem in delivery.DeliveryItems)
            {
                deliveryItem.Item.Stock += deliveryItem.Quantity;    
                itemsRepository.Update(deliveryItem.Item);
            }
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<AdvanceDeliveryResponse>(delivery);
    }
}