using MediatR;

namespace Almox.Application.Features.Almox.Create;

public sealed record CreateSkillRequest(
    string Name,
    int Level
) : IRequest<CreateSkillResponse>;