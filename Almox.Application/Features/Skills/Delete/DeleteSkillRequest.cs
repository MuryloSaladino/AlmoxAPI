using MediatR;

namespace Almox.Application.Features.Almox.Delete;

public sealed record DeleteSkillRequest(
    string Id
) : IRequest<DeleteSkillResponse>; 