using Almox.Domain.Entities;
using Almox.Domain.Objects;

namespace Almox.Application.Contracts;

public interface IAuthenticator {
    string GenerateUserToken(User user);
    AuthPayload ExtractToken(string token);
}