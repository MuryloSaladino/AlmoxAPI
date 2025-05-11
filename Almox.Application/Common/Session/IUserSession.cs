using Almox.Domain.Objects;

namespace Almox.Application.Common.Session;

public interface IUserSession
{
    bool IsLoggedIn();
    AuthPayload GetSession();
    void SetSession(AuthPayload session);
}