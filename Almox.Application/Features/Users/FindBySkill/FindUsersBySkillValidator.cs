using FluentValidation;

namespace Almox.Application.Features.Users.FindBySkill;

public class FindUsersBySkillValidator : AbstractValidator<FindUsersBySkillRequest>
{
    public FindUsersBySkillValidator()
    {
        RuleFor(r => r.SkillNameFilter).MaximumLength(25);
    }
}