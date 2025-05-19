using FluentValidation;

namespace Almox.Application.Features.Orders.AddItem;

public class AddItemToOrderValidator : AbstractValidator<AddItemToOrderRequest>
{
    public AddItemToOrderValidator()
    {
        RuleFor(r => r.Props.Quantity)
            .GreaterThanOrEqualTo(1);
    }
}
