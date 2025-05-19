using FluentValidation;

namespace Almox.Application.Features.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3);
        
        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8);
        
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();
    }
}