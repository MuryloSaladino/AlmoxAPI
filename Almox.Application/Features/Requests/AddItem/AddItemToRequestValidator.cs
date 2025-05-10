using FluentValidation;

namespace Almox.Application.Features.Requests.AddItem;

public class AddItemToRequestValidator : AbstractValidator<AddItemToRequestRequest>
{
    public AddItemToRequestValidator()
    {
        RuleFor(r => r.ItemId).Must(id => Guid.TryParse(id, out _));
        RuleFor(r => r.RequestId).Must(id => Guid.TryParse(id, out _));
        RuleFor(r => r.Quantity).GreaterThanOrEqualTo(1);
    }
}
