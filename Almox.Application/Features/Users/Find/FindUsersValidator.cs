using FluentValidation;

namespace Almox.Application.Features.Users.Find;

public class FindUsersValidator : AbstractValidator<FindUsersRequest>
{
    public FindUsersValidator()
    {
        RuleFor(r => r.Email).MaximumLength(255).When(r => !string.IsNullOrEmpty(r.Email));
        RuleFor(r => r.Username).MaximumLength(255).When(r => !string.IsNullOrEmpty(r.Username));
    }
}