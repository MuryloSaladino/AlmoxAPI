using FluentValidation;

namespace Almox.Application.Features.Deliveries.Create;

public class CreateDeliveryValidator : AbstractValidator<CreateDeliveryRequest>
{
    public CreateDeliveryValidator()
    {
        RuleFor(r => r.Date)
            .Must(d => d > DateTime.Now);

        RuleFor(r => r.Observations)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Observations));
    }
}