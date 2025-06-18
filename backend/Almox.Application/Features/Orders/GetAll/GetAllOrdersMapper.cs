using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.GetAll;

public class GetAllOrdersMapper : Profile
{
    public GetAllOrdersMapper()
    {
        CreateMap<Order, GetAllOrdersResponse>();
    }
}