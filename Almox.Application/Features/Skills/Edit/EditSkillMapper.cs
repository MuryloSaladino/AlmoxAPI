using AutoMapper;
using Almox.Domain.Entities;

namespace Almox.Application.Features.Almox.Edit;

public sealed class EditSkillMapper : Profile
{
    public EditSkillMapper()
    {
        CreateMap<EditSkillRequest, Skill>();
        CreateMap<Skill, EditSkillResponse>();
    }
}