using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Deliveries.Create;

public class CreateDeliveryMapper : Profile
{
    public CreateDeliveryMapper()
    {
        CreateMap<CreateDeliveryRequest, Delivery>();
        CreateMap<Delivery, CreateDeliveryResponse>();
    }
}