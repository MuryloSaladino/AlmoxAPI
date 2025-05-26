using FluentValidation;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(i => i.Description)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(i => i.Stock)
            .GreaterThanOrEqualTo(0);
            
        RuleFor(i => i.Price)
            .GreaterThanOrEqualTo(0);
    }
}