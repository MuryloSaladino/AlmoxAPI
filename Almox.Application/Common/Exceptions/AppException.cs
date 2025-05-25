using Almox.Domain.Common.Exceptions;

namespace Almox.Application.Common.Exceptions;

public class AppException(
    ExceptionCode code,
    string message,
    string? details = null
) : Exception(message)
{
    public ExceptionCode Code { get; } = code;
    public string? Details { get; } = details;

    public static AppException BadRequest(
        string message = ExceptionMessages.BadRequest.Default,
        string? details = null
    ) => new(ExceptionCode.BadRequest, message, details);

    public static AppException Unauthorized(
        string message = ExceptionMessages.Unauthorized.Default,
        string? details = null
    ) => new(ExceptionCode.Unauthorized, message, details);

    public static AppException Forbidden(
        string message = ExceptionMessages.Forbidden.Default,
        string? details = null
    ) => new(ExceptionCode.Forbidden, message, details);

    public static AppException NotFound(
        string message = ExceptionMessages.NotFound.Default,
        string? details = null
    ) => new(ExceptionCode.NotFound, message, details);

    public static AppException Conflict(
        string message = ExceptionMessages.Conflict.Default,
        string? details = null
    ) => new(ExceptionCode.Conflict, message, details);

    public static AppException InternalServerError(
        string message = ExceptionMessages.InternalServerError.Default,
        string? details = null
    ) => new(ExceptionCode.InternalServerError, message, details);

    public static AppException NotImplemented(
        string message = ExceptionMessages.NotImplemented.Default,
        string? details = null
    ) => new(ExceptionCode.NotImplemented, message, details);

    public static AppException BadGateway(
        string message = ExceptionMessages.BadGateway.Default,
        string? details = null
    ) => new(ExceptionCode.BadGateway, message, details);
}
