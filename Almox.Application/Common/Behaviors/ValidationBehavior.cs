using FluentValidation;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Common.Exceptions;

namespace Almox.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => x.ErrorMessage)
            .Distinct()
            .ToArray();

        string message = ExceptionMessages.BadRequest.Format;
        string details = string.Join("\n", errors);

        if (errors.Length != 0)
            throw AppException.BadRequest(message, details);

        return await next();
    }
}