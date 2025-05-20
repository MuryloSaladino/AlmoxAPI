using FluentValidation;

namespace Almox.Application.Features.Items.UpdateImage;

public class UpdateImageItemValidator : AbstractValidator<UpdateImageItemRequest>
{
    public UpdateImageItemValidator()
    {
        RuleFor(i => i.FileName);
    }
}