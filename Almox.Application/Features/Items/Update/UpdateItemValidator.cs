using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(i => i.Props.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(i => i.Props.Quantity)
            .GreaterThanOrEqualTo(0);
            
        RuleFor(i => i.Props.ImageUrl)
            .MaximumLength(255)
            .When(i => !i.Props.ImageUrl.IsNullOrEmpty());
    }
}