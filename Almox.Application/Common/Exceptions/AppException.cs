using Almox.Domain.Common.Enums;

namespace Almox.Application.Common.Exceptions;

public class AppException(
    StatusCode status,
    string message,
    string? details = null
) : Exception(message)
{
    public StatusCode Status { get; } = status;
    public string? Details { get; } = details;
}
