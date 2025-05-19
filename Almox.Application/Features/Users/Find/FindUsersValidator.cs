using FluentValidation;

namespace Almox.Application.Features.Users.Find;

public class FindUsersValidator : AbstractValidator<FindUsersRequest>
{
    public FindUsersValidator()
    {
        RuleFor(r => r.Filters.Email)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Filters.Email));

        RuleFor(r => r.Filters.Username)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Filters.Username));
    }
}