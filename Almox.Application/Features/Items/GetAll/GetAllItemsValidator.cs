using FluentValidation;

namespace Almox.Application.Features.Items.GetAll;

public class GetAllItemsValidator : AbstractValidator<GetAllItemsRequest>
{
    public GetAllItemsValidator()
    {
        RuleFor(r => r.Filters.Name)
            .MaximumLength(50)
            .When(r => !string.IsNullOrEmpty(r.Filters.Name));

        RuleFor(r => r.Filters.CategoryName)
            .MaximumLength(50)
            .When(r => !string.IsNullOrEmpty(r.Filters.CategoryName));
    }
}