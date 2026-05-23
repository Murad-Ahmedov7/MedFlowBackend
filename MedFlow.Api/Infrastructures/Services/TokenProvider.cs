
using Application.Infrastructure;
using Domain.Entities.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class TokenProvider : ITokenProvider
{

    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(User user)
    {
        var jwtSection = _configuration.GetSection("Jwt");

        var keyString = jwtSection["Key"]
            ?? throw new Exception("JWT Key is missing in appsettings.json");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(keyString)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>
            {
                // JWT standard
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Role,user.UserRole.ToString())

            };

        var expireMinutes = int.Parse(jwtSection["ExpireMinutes"]!);

        var token = new JwtSecurityToken(
            issuer: jwtSection["Issuer"],
            audience: jwtSection["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expireMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}

