using Almox.Domain.Objects;

namespace Almox.Application.Common.Session;

public interface IRequestSession
{
    SessionData GetSessionOrThrow();
    void SetSession(SessionData session);
}