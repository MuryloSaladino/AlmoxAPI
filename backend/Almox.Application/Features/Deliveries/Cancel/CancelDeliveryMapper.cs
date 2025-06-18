using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Deliveries.Cancel;

public class CancelDeliveryMapper : Profile
{
    public CancelDeliveryMapper()
    {
        CreateMap<Delivery, CancelDeliveryResponse>();
    }
}