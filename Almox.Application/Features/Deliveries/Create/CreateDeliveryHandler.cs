using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.Deliveries;
using Almox.Application.Repository.Users;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Deliveries.Create;

public class CreateDeliveryHandler(
    IDeliveryHistoryRepository historyRepository,
    IDeliveriesRepository deliveriesRepository,
    IUsersRepository usersRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateDeliveryRequest, CreateDeliveryResponse>
{
    public async Task<CreateDeliveryResponse> Handle(
        CreateDeliveryRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var user = await usersRepository.Get(session.UserId, cancellationToken)
            ?? throw AppException.NotFound(ExceptionMessages.NotFound.User);

        var delivery = mapper.Map<Delivery>(request);

        delivery.UserId = session.UserId;

        deliveriesRepository.Create(delivery);

        historyRepository.Create(new()
        {
            Delivery = delivery,
            DeliveryId = delivery.Id,
            UpdatedBy = user,
            UpdatedById = delivery.UserId,
            Status = delivery.Status
        });

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateDeliveryResponse>(delivery);
    }
}