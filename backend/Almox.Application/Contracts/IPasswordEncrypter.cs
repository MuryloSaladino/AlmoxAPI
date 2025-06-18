using Almox.Domain.Entities;

namespace Almox.Application.Contracts;

public interface IPasswordEncrypter
{
    string Hash(User user);
    bool Matches(User user, string password);
}