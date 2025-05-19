using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class ForbiddenException(
    string message = ExceptionMessages.Forbidden.Default,
    string? details = null
) : AppException(StatusCode.Forbidden, message, details);