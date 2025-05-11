using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Domain.Common.Messages;
using Almox.Domain.Objects;

namespace Almox.API.Security.Session;

public class UserSession(AuthPayload? session = null) : IUserSession
{
    public AuthPayload? Session { get; set; } = session;

    public bool IsLoggedIn() => Session != null;

    public AuthPayload GetSession()
        => Session ?? throw new UnauthorizedException(ExceptionMessages.Unauthorized.Session);

    public void SetSession(AuthPayload? session)
        => Session = session;
}