using FluentValidation;

namespace Almox.Application.Features.Orders.Cancel;

public class CancelOrderValidator : AbstractValidator<CancelOrderRequest>
{
    public CancelOrderValidator()
    {
        RuleFor(r => r.Observations)
            .NotEmpty()
            .MaximumLength(255);
    }
}