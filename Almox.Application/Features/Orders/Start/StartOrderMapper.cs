using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Start;

public class CreateOrderMapper : Profile
{
    public CreateOrderMapper()
    {
        CreateMap<OrderItem, StartOrderItemPresenter>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Order, StartOrderResponse>();
    }
}