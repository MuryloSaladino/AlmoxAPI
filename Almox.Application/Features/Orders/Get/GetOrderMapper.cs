using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Get;

public class GetOrderMapper : Profile
{
    public GetOrderMapper()
    {
        CreateMap<Order, GetOrderResponse>();
    }
}