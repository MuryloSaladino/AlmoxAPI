namespace Almox.Application.Common.Exceptions;

public class AppException(
    string message,
    AppExceptionCode statusCode = AppExceptionCode.BadRequest
) : Exception(message)
{
    public AppExceptionCode StatusCode { get; set; } = statusCode;
}

public enum AppExceptionCode
{
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    ImATeapot = 418,
    InternalServerError = 500,
    NotImplemented = 501,
}