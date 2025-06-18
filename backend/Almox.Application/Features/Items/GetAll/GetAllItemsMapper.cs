using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.GetAll;

public class FindItemsMapper : Profile
{
    public FindItemsMapper()
    {
        CreateMap<Item, GetAllItemsResponse>();
    }
}