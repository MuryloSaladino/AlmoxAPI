using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.Promote;

public sealed class PromoteUserMapper : Profile
{
    public PromoteUserMapper()
    {
        CreateMap<User, PromoteUserResponse>();
    }
}