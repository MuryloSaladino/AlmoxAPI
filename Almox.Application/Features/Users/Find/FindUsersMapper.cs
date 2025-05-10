using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Users.Find;

public class FindUsersMapper : Profile
{
    public FindUsersMapper()
    {
        CreateMap<User, FindUsersResponse>();
    }
}