using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.FindById;

public class FindUserByIdMapper : Profile
{
    public FindUserByIdMapper()
    {
        CreateMap<User, FindUserByIdResponse>();
    }
}