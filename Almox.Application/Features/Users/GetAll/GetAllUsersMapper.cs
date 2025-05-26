using Almox.Domain.Entities;
using AutoMapper;

namespace Almox.Application.Features.Users.GetAll;

public class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<User, GetAllUsersResponse>();
    }
}