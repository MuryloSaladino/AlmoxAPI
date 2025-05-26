using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Update;

public class UpdateOrderMapper : Profile
{
    public UpdateOrderMapper()
    {
        CreateMap<Order, UpdateOrderResponse>();
    }
}