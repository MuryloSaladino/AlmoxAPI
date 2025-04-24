using FluentValidation;

namespace Almox.Application.Features.Almox.Delete;

public class DeleteSkillValidator : AbstractValidator<DeleteSkillRequest>
{
    public DeleteSkillValidator()
    {
        RuleFor(r => r.Id).Must(id => Guid.TryParse(id, out _));
    }
}