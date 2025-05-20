using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class AppException(
    StatusCode status,
    string message,
    string? details = null
) : Exception(message)
{
    public StatusCode Status { get; } = status;
    public string? Details { get; } = details;

    public static AppException BadRequest(
        string message = ExceptionMessages.BadRequest.Default,
        string? details = null
    ) => new(StatusCode.BadRequest, message, details);

    public static AppException Unauthorized(
        string message = ExceptionMessages.Unauthorized.Default,
        string? details = null
    ) => new(StatusCode.Unauthorized, message, details);

    public static AppException Forbidden(
        string message = ExceptionMessages.Forbidden.Default,
        string? details = null
    ) => new(StatusCode.Forbidden, message, details);

    public static AppException NotFound(
        string message = ExceptionMessages.NotFound.Default,
        string? details = null
    ) => new(StatusCode.NotFound, message, details);

    public static AppException Conflict(
        string message = ExceptionMessages.Conflict.Default,
        string? details = null
    ) => new(StatusCode.Conflict, message, details);

    public static AppException InternalServerError(
        string message = ExceptionMessages.InternalServerError.Default,
        string? details = null
    ) => new(StatusCode.InternalServerError, message, details);

    public static AppException NotImplemented(
        string message = ExceptionMessages.NotImplemented.Default,
        string? details = null
    ) => new(StatusCode.NotImplemented, message, details);

    public static AppException BadGateway(
        string message = ExceptionMessages.BadGateway.Default,
        string? details = null
    ) => new(StatusCode.BadGateway, message, details);
}
