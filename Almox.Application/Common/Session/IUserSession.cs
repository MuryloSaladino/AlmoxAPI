using Almox.Domain.Objects;

namespace Almox.Application.Common.Session;

public interface IUserSession
{
    bool IsLoggedIn();
    AuthPayload GetSessionOrThrow();
    void SetSession(AuthPayload session);
}