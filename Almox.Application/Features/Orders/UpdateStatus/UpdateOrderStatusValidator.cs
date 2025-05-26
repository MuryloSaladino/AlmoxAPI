using FluentValidation;

namespace Almox.Application.Features.Orders.UpdateStatus;

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusRequest>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(r => r.Status)
            .NotNull();

        RuleFor(r => r.Observations)
            .MaximumLength(255)
            .When(r => !string.IsNullOrEmpty(r.Observations));
    }
}