using MediatR;

namespace Almox.Application.Features.Almox.Edit;

public sealed class EditSkillRequest(
    string id,
    string name,
    int level
) : IRequest<EditSkillResponse>
{
    public string? Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
}