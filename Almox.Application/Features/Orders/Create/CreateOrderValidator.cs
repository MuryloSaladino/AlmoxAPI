using FluentValidation;

namespace Almox.Application.Features.Orders.Create;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.Observations)
            .MaximumLength(255)
            .When(o => !string.IsNullOrEmpty(o.Observations));

        RuleFor(o => o.Priority)
            .NotNull();

        RuleForEach(o => o.OrderedItems)
            .ChildRules(o =>
            {
                o.RuleFor(oi => oi.ItemId)
                    .NotNull();
                o.RuleFor(oi => oi.Quantity)
                    .NotNull()
                    .GreaterThanOrEqualTo(1);
            });
    }
}