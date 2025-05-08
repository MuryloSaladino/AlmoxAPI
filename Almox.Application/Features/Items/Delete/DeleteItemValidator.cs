using FluentValidation;

namespace Almox.Application.Features.Items.Delete;

public class DeleteItemValidator : AbstractValidator<DeleteItemRequest>
{
    public DeleteItemValidator()
    {
        RuleFor(r => r.Id).Must(id => Guid.TryParse(id, out _));
    }
}