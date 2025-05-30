using Almox.Domain.Entities;
using Almox.Domain.Objects;

namespace Almox.Application.Contracts;

public interface IAuthenticator {
    string GenerateToken(User user);
    SessionData ExtractToken(string token);
}