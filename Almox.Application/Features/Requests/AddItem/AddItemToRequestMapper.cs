using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestMapper : Profile
{
    public AddItemToRequestMapper()
    {
        CreateMap<AddItemToRequestRequest, RequestItem>()
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => Guid.Parse(src.ItemId)))
            .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => Guid.Parse(src.RequestId)));
            
        CreateMap<RequestItem, AddItemToRequestResponse>();
    }
}