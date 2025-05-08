using FluentValidation;

namespace Almox.Application.Features.Categories.Delete;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryRequest>
{
    public DeleteCategoryValidator()
    {
        RuleFor(r => r.Id).Must(id => Guid.TryParse(id, out _));
    }
}