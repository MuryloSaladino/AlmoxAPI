using FluentValidation;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestValidator : AbstractValidator<AddItemToRequestRequest>
{
    public AddItemToRequestValidator()
    {
        RuleFor(r => r.Props.Quantity).GreaterThanOrEqualTo(1);
    }
}
