using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.Find;

public class FindItemsMapper : Profile
{
    public FindItemsMapper()
    {
        CreateMap<Item, FindItemsResponse>();
    }
}