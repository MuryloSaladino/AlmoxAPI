using FluentValidation;

namespace Almox.Application.Features.Orders.Advance;

public class AdvanceOrderValidator : AbstractValidator<AdvanceOrderRequest>
{
    public AdvanceOrderValidator()
    {
        RuleFor(r => r.Observations)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Observations));
    }
}