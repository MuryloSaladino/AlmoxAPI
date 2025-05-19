using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestMapper : Profile
{
    public AddItemToRequestMapper()
    {
        CreateMap<AddItemToRequestRequest, RequestItem>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Props.Quantity));
            
        CreateMap<RequestItem, AddItemToRequestResponse>();
    }
}