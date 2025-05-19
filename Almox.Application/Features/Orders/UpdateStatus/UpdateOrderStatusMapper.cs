using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Orders.UpdateStatus;

public class UpdateOrderStatusMapper : Profile
{
    public UpdateOrderStatusMapper()
    {
        CreateMap<Order, UpdateOrderStatusResponse>();
    }
}