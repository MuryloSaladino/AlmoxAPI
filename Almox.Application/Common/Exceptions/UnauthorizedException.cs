using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class UnauthorizedException(
    string message = ExceptionMessages.Unauthorized.Default,
    string? details = null
) : AppException(StatusCode.Unauthorized, message, details) { }