using FluentValidation;

namespace Almox.Application.Features.Orders.GetAll;

public class GetAllOrdersValidator : AbstractValidator<GetAllOrdersRequest>
{
    public GetAllOrdersValidator()
    {
        RuleFor(r => r.Filters.PageSize)
            .LessThanOrEqualTo(20);
    }
}