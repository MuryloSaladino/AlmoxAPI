using FluentValidation;

namespace Almox.Application.Features.Users.GetAll;

public class GetAllUsersValidator : AbstractValidator<GetAllUsersRequest>
{
    public GetAllUsersValidator()
    {
        RuleFor(r => r.Email)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Email));

        RuleFor(r => r.Username)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Username));
    }
}