namespace Almox.Domain.Common.Exceptions;

public class ExceptionData
{
    public ExceptionCode ExceptionCode { get; set; }
    public string Message { get; set; }
    public string? Details { get; set; }

    public ExceptionData(ExceptionCode exceptionCode, string message, string? details = null)
    {
        ExceptionCode = exceptionCode;
        Message = message;
        Details = details;
    }

    public ExceptionData(Exception? ex = null)
    {
        ExceptionCode = ExceptionCode.InternalServerError;
        Message = ExceptionMessages.InternalServerError.Default;
        Details = ex?.Message;
    }
}