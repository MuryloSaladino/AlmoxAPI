using FluentValidation;

namespace Almox.Application.Features.Deliveries.Create;

public class CreateDeliveryValidator : AbstractValidator<CreateDeliveryRequest>
{
    public CreateDeliveryValidator()
    {
        RuleFor(r => r.Supplier)
            .MaximumLength(35);

        RuleFor(r => r.ExpectedDate)
            .Must(d => d > DateTime.UtcNow.AddDays(1));

        RuleFor(r => r.Observations)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Observations));
    }
}