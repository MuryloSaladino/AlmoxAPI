using FluentValidation;

namespace Almox.Application.Features.Items.GetAll;

public class GetAllItemsValidator : AbstractValidator<GetAllItemsRequest>
{
    public GetAllItemsValidator()
    {
        RuleFor(r => r.Name)
            .MaximumLength(50)
            .When(r => !string.IsNullOrEmpty(r.Name));

        RuleFor(r => r.CategoryName)
            .MaximumLength(50)
            .When(r => !string.IsNullOrEmpty(r.CategoryName));
    }
}