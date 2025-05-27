using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.Cancel;

public class CancelOrderMapper : Profile
{
    public CancelOrderMapper()
    {
        CreateMap<Order, CancelOrderResponse>();
    }
}