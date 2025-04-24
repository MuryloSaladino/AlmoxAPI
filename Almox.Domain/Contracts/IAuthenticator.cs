using Almox.Domain.Common;
using Almox.Domain.Entities;

namespace Almox.Domain.Contracts;

public interface IAuthenticator {
    string GenerateUserToken(User user);
    UserSession ExtractToken(string token);
}