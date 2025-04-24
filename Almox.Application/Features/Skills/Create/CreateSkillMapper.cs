using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Almox.Create;

public sealed class CreateSkillMapper : Profile
{
    public CreateSkillMapper()
    {
        CreateMap<CreateSkillRequest, Skill>();
        CreateMap<Skill, CreateSkillResponse>();
    }
}