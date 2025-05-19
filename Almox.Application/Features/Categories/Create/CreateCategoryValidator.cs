using FluentValidation;

namespace Almox.Application.Features.Categories.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(35);
            
        RuleFor(c => c.Description)
            .NotEmpty()
            .MaximumLength(255);
    }
}