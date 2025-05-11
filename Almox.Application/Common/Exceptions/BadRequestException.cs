using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;

namespace Almox.Application.Common.Exceptions;

public class BadRequestException(
    string message = ExceptionMessages.BadRequest.Default,
    string? details = null
) : AppException(StatusCode.BadRequest, message, details) { }