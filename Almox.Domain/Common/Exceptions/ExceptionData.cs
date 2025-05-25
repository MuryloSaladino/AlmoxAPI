namespace Almox.Domain.Common.Exceptions;

public class ErrorSummary
{
    public ExceptionCode ExceptionCode { get; set; }
    public string Message { get; set; }
    public string? Details { get; set; }

    public ErrorSummary(ExceptionCode exceptionCode, string message, string? details = null)
    {
        ExceptionCode = exceptionCode;
        Message = message;
        Details = details;
    }

    public ErrorSummary(Exception? ex = null)
    {
        ExceptionCode = ExceptionCode.InternalServerError;
        Message = ExceptionMessages.InternalServerError.Default;
        Details = ex?.Message;
    }
}