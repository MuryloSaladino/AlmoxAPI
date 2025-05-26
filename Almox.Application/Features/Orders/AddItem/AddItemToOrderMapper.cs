using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.AddItem;

public class AddItemToOrderMapper : Profile
{
    public AddItemToOrderMapper()
    {
        CreateMap<AddItemToOrderRequest, OrderItem>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
            
        CreateMap<OrderItem, AddItemToOrderResponse>();
    }
}