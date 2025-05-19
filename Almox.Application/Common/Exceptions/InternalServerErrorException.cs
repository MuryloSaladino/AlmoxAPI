using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class InternalServerErrorException(
    string message = ExceptionMessages.InternalServerError.Default,
    string? details = null
) : AppException(StatusCode.InternalServerError, message, details);