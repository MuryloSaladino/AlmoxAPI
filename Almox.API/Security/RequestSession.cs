using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;
using Almox.Domain.Objects;

namespace Almox.API.Security;

public class RequestSession(SessionData? session = null) : IRequestSession
{
    public SessionData? Session { get; set; } = session;
    
    public void SetSession(SessionData? session)
        => Session = session;

    public SessionData GetSessionOrThrow()
        => Session ?? throw AppException.Unauthorized(ExceptionMessages.Unauthorized.Session);

    public SessionData GetStaffSessionOrThrow()
    {
        var session = GetSessionOrThrow();

        if (session.Role.Equals(UserRole.Employee))
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Role);

        return session;
    }

    public SessionData GetAdminSessionOrThrow()
    {
        var session = GetSessionOrThrow();

        if (!session.Role.Equals(UserRole.Admin))
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Role);

        return session;
    }
}