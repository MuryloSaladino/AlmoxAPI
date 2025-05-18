using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Requests.Start;

public class CreateRequestMapper : Profile
{
    public CreateRequestMapper()
    {
        CreateMap<Request, StartRequestResponse>();
    }
}