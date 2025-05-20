using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Items.UpdateImage;

public class UpdateImageItemMapper : Profile
{
    public UpdateImageItemMapper()
    {
        CreateMap<Item, UpdateImageItemResponse>();
    }
}