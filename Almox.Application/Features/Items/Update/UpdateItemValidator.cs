using FluentValidation;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(i => i.Props.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .When(i => !string.IsNullOrEmpty(i.Props.Name));
        
        RuleFor(i => i.Props.Quantity)
            .GreaterThanOrEqualTo(0)
            .When(i => i.Props.Quantity.HasValue);
    }
}