using FluentValidation;

namespace Almox.Application.Features.Deliveries.Cancel;

public class CancelDeliveryValidator : AbstractValidator<CancelDeliveryRequest>
{
    public CancelDeliveryValidator()
    {
        RuleFor(r => r.Observations)
            .NotEmpty()
            .MaximumLength(255);
    }
}