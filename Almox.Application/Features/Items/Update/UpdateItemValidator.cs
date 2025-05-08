using FluentValidation;

namespace Almox.Application.Features.Items.Update;

public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(i => i.Id).Must(id => Guid.TryParse(id, out _));
        RuleFor(i => i.Name).NotEmpty().MinimumLength(2).MaximumLength(50).When(i => i.Name is not null);
        RuleFor(i => i.Quantity).GreaterThanOrEqualTo(0).When(i => i.Quantity.HasValue);
    }
}