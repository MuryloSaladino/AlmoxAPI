using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Entities;
using Almox.Application.Contracts;
using Almox.Domain.Objects;
using Almox.Domain.Common.Messages;
using Almox.API.Config;

namespace Almox.API.Services;

public class AuthenticationService : IAuthenticator
{
    public string SecretKey { get; private set; } = DotEnv.Get("SECRET_KEY");
    public int ExpireHours { get; private set; } = int.Parse(DotEnv.Get("EXPIRE_HOURS"));

    private static class PayloadKeys
    {
        public const string UserId = "sub";
        public const string IsAdmin = "admin";
    }

    public string GenerateUserToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([ 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(PayloadKeys.UserId, user.Id.ToString()),
                new Claim(PayloadKeys.IsAdmin, user.IsAdmin.ToString()),
            ]),
            
            Expires = DateTime.UtcNow.AddHours(ExpireHours),
            
            SigningCredentials = new(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            ),
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
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var userId = principal.FindFirst(PayloadKeys.UserId)?.Value
                ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? throw new SecurityTokenException($"Invalid token: missing {PayloadKeys.UserId} claim.");

            var isAdmin = bool.Parse(principal.FindFirst(PayloadKeys.IsAdmin)?.Value ?? "False");

            if(!Guid.TryParse(userId, out Guid parsedId))
                throw new SecurityTokenException("Invalid token: user id format.");

            return new SessionData
            {
                UserId = parsedId,
                IsAdmin = isAdmin,
            };
        }
        catch(Exception e)
        {
            throw new UnauthorizedException(ExceptionMessages.Unauthorized.Token, e.Message);
        }
    }
}

