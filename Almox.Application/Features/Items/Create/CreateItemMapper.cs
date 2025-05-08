using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.Create;

public class CreateItemMapper : Profile
{
    public CreateItemMapper()
    {
        CreateMap<CreateItemRequest, Item>();
        CreateMap<Item, CreateItemResponse>();
    }
}