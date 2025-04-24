using MediatR;

namespace Almox.Application.Features.Users.FindBySkill;

public sealed record FindUsersBySkillRequest(
    string SkillNameFilter
) : IRequest<List<FindUsersBySkillResponse>>;