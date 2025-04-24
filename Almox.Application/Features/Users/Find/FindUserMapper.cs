using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.Find;

public class FindUserMapper : Profile
{
    public FindUserMapper()
    {
        CreateMap<User, FindUserResponse>();
    }
}