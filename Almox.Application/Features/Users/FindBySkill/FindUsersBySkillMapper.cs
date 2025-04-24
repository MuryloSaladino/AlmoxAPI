using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Users.FindBySkill;

public class FindUsersBySkillMapper : Profile
{
    public FindUsersBySkillMapper()
    {
        CreateMap<User, FindUsersBySkillResponse>();
    }
}