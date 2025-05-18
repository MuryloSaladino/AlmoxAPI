using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.Update;

public class UpdateRequestMapper : Profile
{
    public UpdateRequestMapper()
    {
        CreateMap<RequestItem, UpdateRequestStatusResponseItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Request, UpdateRequestResponse>();
    }
}