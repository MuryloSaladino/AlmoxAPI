using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemMapper : Profile
{
    public UpdateItemMapper()
    {
        CreateMap<Item, UpdateItemResponse>();
    }
}