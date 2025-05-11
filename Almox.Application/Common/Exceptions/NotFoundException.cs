using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class NotFoundException(
    string message = ExceptionMessages.NotFound.Default,
    string? details = null
) : AppException(StatusCode.NotFound, message, details) { }