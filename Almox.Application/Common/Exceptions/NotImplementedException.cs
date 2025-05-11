using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class NotImplementedException(
    string message = ExceptionMessages.NotImplemented.Default,
    string? details = null
) : AppException(StatusCode.NotImplemented, message, details) { }