using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.FindById;

public class FindRequestByIdMapper : Profile
{
    public FindRequestByIdMapper()
    {
        CreateMap<RequestItem, FindRequestByIdItemPresenter>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Request, FindRequestByIdResponse>();
    }
}