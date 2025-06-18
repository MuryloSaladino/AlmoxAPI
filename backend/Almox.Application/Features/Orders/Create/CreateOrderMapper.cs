using Almox.Application.Common.Generators;
using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Create;

public class CreateOrderMapper : Profile
{
    public CreateOrderMapper()
    {
        CreateMap<CreateOrderRequest, Order>()
            .ForMember(dest => dest.Tracking, opt => opt.MapFrom(_ => TrackingCodeGenerator.Generate()));
        CreateMap<Order, CreateOrderResponse>();
    }
}