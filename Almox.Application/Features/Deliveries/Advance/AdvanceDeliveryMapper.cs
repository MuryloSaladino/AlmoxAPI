using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Deliveries.Advance;

public class AdvanceDeliveryMapper : Profile
{
    public AdvanceDeliveryMapper()
    {
        CreateMap<Delivery, AdvanceDeliveryResponse>();
    }
}