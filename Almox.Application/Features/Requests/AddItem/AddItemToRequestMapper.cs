using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestMapper : Profile
{
    public AddItemToRequestMapper()
    {
        CreateMap<AddItemToRequestRequest, RequestItem>();
        CreateMap<RequestItem, AddItemToRequestResponse>();
    }
}