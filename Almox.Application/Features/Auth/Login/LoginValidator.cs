using FluentValidation;

namespace Almox.Application.Features.Auth.Login;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(l => l.UserIdentifier)
            .NotEmpty();

        RuleFor(l => l.Password)
            .NotEmpty();
    }
}