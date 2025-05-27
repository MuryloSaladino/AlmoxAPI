using FluentValidation;

namespace Almox.Application.Features.Deliveries.Advance;

public class AdvanceDeliveryValidator : AbstractValidator<AdvanceDeliveryRequest>
{
    public AdvanceDeliveryValidator()
    {
        RuleFor(r => r.Observations)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Observations));
    }
}