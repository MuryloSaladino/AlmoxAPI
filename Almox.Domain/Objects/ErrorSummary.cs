using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Domain.Objects;

public class ErrorSummary
{
    public StatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public string? Details { get; set; }

    public ErrorSummary(StatusCode statusCode, string message, string? details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }

    public ErrorSummary(Exception? ex = null)
    {
        StatusCode = StatusCode.InternalServerError;
        Message = ExceptionMessages.InternalServerError.Default;
        Details = ex?.Message;
    }
}