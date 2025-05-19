using FluentValidation;

namespace Almox.Application.Features.Items.Create;

public class CreateItemValidator : AbstractValidator<CreateItemRequest>
{
    public CreateItemValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }
}