using FluentValidation;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(i => i.Props.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(i => i.Props.Description)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(i => i.Props.Stock)
            .GreaterThanOrEqualTo(0);
            
        RuleFor(i => i.Props.Price)
            .GreaterThanOrEqualTo(0);
    }
}