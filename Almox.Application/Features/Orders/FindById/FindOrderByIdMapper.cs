using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.FindById;

public class FindOrderByIdMapper : Profile
{
    public FindOrderByIdMapper()
    {
        CreateMap<OrderItem, FindOrderByIdItemPresenter>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Item.ImageUrl))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Order, FindOrderByIdResponse>();
    }
}