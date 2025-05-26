using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Entities;
using Almox.Application.Contracts;
using Almox.Domain.Objects;
using Microsoft.IdentityModel.Protocols.Configuration;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Exceptions;

namespace Almox.API.Services;

public class AuthenticationService : IAuthenticator
{
    private string SecretKey { get; } = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? throw new InvalidConfigurationException("The environment needs \"SECRET_KEY\" variable");
    private string Issuer { get; } = Environment.GetEnvironmentVariable("JWT_ISSUER")
        ?? throw new InvalidConfigurationException("The environment needs \"JWT_ISSUER\" variable");
    private int ExpireHours { get; } = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRE_HOURS") ?? "3");

    private static class PayloadKeys
    {
        public const string User = "userId";
        public const string Role = "userRole";
    }

    public string GenerateUserToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([
                new Claim(PayloadKeys.User, user.Id.ToString()),
                new Claim(PayloadKeys.Role, user.Role.ToString()),
            ]),
            SigningCredentials = new(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Issuer = Issuer,
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddHours(ExpireHours),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public SessionData ExtractToken(string token)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidIssuer = Issuer,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var userId = principal.FindFirst(PayloadKeys.User)?.Value
                ?? throw new SecurityTokenException($"Invalid token: missing { PayloadKeys.User } claim.");

            var role = principal.FindFirst(PayloadKeys.Role)?.Value
                ?? throw new SecurityTokenException($"Invalid token: missing { PayloadKeys.Role } claim.");

            if(!Guid.TryParse(userId, out Guid parsedId))
                throw new SecurityTokenException($"Invalid token: { PayloadKeys.User } format.");
            
            if(!Enum.TryParse(role, out UserRole parsedRole))
                throw new SecurityTokenException($"Invalid token: { PayloadKeys.Role } format.");

            return new SessionData
            {
                UserId = parsedId,
                Role = parsedRole,
            };
        }
        catch(Exception e)
        {
            throw AppException.Unauthorized(ExceptionMessages.Unauthorized.Token, e.Message);
        }
    }
}

