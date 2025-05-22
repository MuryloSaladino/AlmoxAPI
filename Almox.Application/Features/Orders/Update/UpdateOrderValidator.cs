using FluentValidation;

namespace Almox.Application.Features.Orders.Update;

public class UpdateRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateRequestValidator()
    {
        RuleFor(r => r.Props.Observations)
            .MaximumLength(255)
            .When(r => !string.IsNullOrWhiteSpace(r.Props.Observations));
    }
}