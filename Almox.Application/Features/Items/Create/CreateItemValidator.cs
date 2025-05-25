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

        RuleFor(i => i.CategoryIds)
            .Must(c => c.Count > 0);

        RuleFor(i => i.Description)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(i => i.Price)
            .NotEmpty();

        RuleFor(i => i.Stock)
            .NotEmpty();
    }
}