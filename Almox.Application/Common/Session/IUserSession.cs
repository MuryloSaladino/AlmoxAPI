using Almox.Domain.Objects;

namespace Almox.Application.Common.Session;

public interface IRequestSession
{
    SessionData GetSessionOrThrow();
    SessionData GetStaffSessionOrThrow();
    SessionData GetAdminSessionOrThrow();
    void SetSession(SessionData session);
}