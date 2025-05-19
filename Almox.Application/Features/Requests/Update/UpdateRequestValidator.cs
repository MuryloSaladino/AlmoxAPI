using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Almox.Application.Features.Requests.Update;

public class UpdateRequestValidator : AbstractValidator<UpdateRequestRequest>
{
    public UpdateRequestValidator()
    {
        RuleFor(r => r.Props.Observations)
            .MaximumLength(255)
            .When(r => !r.Props.Observations.IsNullOrEmpty());
    }
}