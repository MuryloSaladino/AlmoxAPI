using FluentValidation;

namespace Almox.Application.Features.Users.FindById;

public class FindUserByIdValidator : AbstractValidator<FindUserByIdRequest>
{
    public FindUserByIdValidator()
    {
        RuleFor(u => u.Id).Must(id => Guid.TryParse(id, out _));
    }
}