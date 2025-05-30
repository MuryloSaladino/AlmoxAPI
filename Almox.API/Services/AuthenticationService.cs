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

namespace Almox.API.Services;

public class AuthenticationService : IAuthenticator
{
    private string SecretKey { get; } = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? throw new InvalidConfigurationException("The environment needs \"SECRET_KEY\" variable");
    private string Issuer { get; } = Environment.GetEnvironmentVariable("JWT_ISSUER")
        ?? throw new InvalidConfigurationException("The environment needs \"JWT_ISSUER\" variable");


    public string GenerateToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ]),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Issuer = Issuer,
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(15)
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
            ValidateIssuer = true,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new SecurityTokenException("Missing 'sub' claim");

            var role = principal.FindFirst(ClaimTypes.Role)?.Value
                ?? throw new SecurityTokenException("Missing 'role' claim");

            if (!Guid.TryParse(userId, out var parsedId))
                throw new SecurityTokenException("Invalid 'sub' claim format");

            if (!Enum.TryParse(role, out UserRole parsedRole))
                throw new SecurityTokenException("Invalid 'role' claim format");

            return new SessionData
            {
                UserId = parsedId,
                Role = parsedRole
            };
        }
        catch (Exception ex)
        {
            throw AppException.Unauthorized(ex.Message);
        }
    }
}

