using FluentValidation;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(i => i.Body.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .When(i => !string.IsNullOrEmpty(i.Body.Name));
        
        RuleFor(i => i.Body.Quantity)
            .GreaterThanOrEqualTo(0)
            .When(i => i.Body.Quantity.HasValue);
    }
}