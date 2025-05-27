using Almox.Application.Common.Generators;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using Almox.Application.Repository.Items;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.Create;

public class CreateDeliveryHandler(
    IDeliveryStatusUpdatesRepository statusUpdatesRepository,
    IDeliveriesRepository deliveriesRepository,
    IItemsRepository itemsRepository,
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

        var itemIds = request.Items.Select(x => x.ItemId);
        var itemsDict = request.Items.ToDictionary(x => x.ItemId);
        var items = await itemsRepository.GetAll(itemIds, cancellationToken);

        delivery.DeliveryItems = [..items.Select(item => new DeliveryItem
        {
            ItemId = item.Id,
            Item = item,
            DeliveryId = delivery.Id,
            SupplierPrice = itemsDict[item.Id].SupplierPrice,
            Quantity = itemsDict[item.Id].Quantity
        })];

        deliveriesRepository.Create(delivery);

        statusUpdatesRepository.Create(new()
        {
            DeliveryId = delivery.Id,
            UpdatedById = session.UserId,
            Status = delivery.Status,
            Observations = request.Observations
        });

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateDeliveryResponse>(delivery);
    }
}