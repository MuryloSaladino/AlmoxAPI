using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Domain.Common.Messages;
using Almox.Domain.Objects;

namespace Almox.API.Security;

public class RequestSession(SessionData? session = null) : IRequestSession
{
    public SessionData? Session { get; set; } = session;

    public SessionData GetSessionOrThrow()
        => Session ?? throw AppException.Unauthorized(ExceptionMessages.Unauthorized.Session);

    public void SetSession(SessionData? session)
        => Session = session;
}