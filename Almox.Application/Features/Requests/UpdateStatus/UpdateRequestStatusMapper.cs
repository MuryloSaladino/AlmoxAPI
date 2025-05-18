using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.UpdateStatus;

public class UpdateRequestStatusMapper : Profile
{
    public UpdateRequestStatusMapper()
    {
        CreateMap<Request, UpdateRequestStatusResponse>();
    }
}