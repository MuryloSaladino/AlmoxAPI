using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Almox.Application.Common.Exceptions;
using Almox.Application.Config;
using Almox.Domain.Entities;
using Almox.Application.Contracts;
using Almox.Domain.Objects;
using Almox.Domain.Common.Messages;

namespace Almox.API.Services;

public class AuthenticationService : IAuthenticator
{
    public string SecretKey { get; private set; } = DotEnv.Get("SECRET_KEY");
    public int ExpireHours { get; private set; } = int.Parse(DotEnv.Get("EXPIRE_HOURS"));

    public string GenerateUserToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([ 
                new Claim("userId", user.Id.ToString()),
                new Claim("username", user.Username), 
                new Claim("isAdmin", user.IsAdmin.ToString())
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

    public AuthPayload ExtractToken(string token)
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
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var userId = principal.FindFirst("userId")?.Value;
            var username = principal.FindFirst("username")?.Value;
            var isAdmin = bool.Parse( principal.FindFirst("isAdmin")?.Value ?? "False" );

            if(userId == null || username == null)
                throw new SecurityTokenException("Invalid token: missing claims.");

            if(!Guid.TryParse(userId, out Guid parsedId))
                throw new SecurityTokenException("Invalid token: user id format.");

            return new AuthPayload
            {
                UserId = parsedId,
                Username = username,
                IsAdmin = isAdmin,
            };
        }
        catch(Exception e)
        {
            throw new UnauthorizedException(ExceptionMessages.Unauthorized.Token, e.Message);
        }
    }
}

