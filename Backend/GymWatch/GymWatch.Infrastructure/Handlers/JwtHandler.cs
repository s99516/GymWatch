using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.Extensions;
using GymWatch.Infrastructure.Handlers.Abstraction;
using GymWatch.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

public class JwtHandler : IJwtHandler
{
    private readonly JwtSettings _settings;
    
    public JwtHandler(JwtSettings settings)
    {
        _settings = settings;
    }

    public JwtDto CreateToken(string email)
    {
        var now = DateTime.UtcNow;

        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.UniqueName, email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
        };

        var expiry = now.AddMinutes(_settings.ExpiryMinutes);

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer: _settings.Issuer,
            claims: claims,
            notBefore: now,
            expires: expiry,
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new JwtDto
        {
            Token = token,
            Expires = expiry.ToTimeStamp()
        };
    }
}