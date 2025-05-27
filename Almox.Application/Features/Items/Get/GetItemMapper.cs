using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.Get;

public class GetItemMapper : Profile
{
    public GetItemMapper()
    {
        CreateMap<Item, GetItemResponse>();
    }
}