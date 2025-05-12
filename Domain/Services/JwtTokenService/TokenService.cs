using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Services.JwtTokenService;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey key;
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:TokenKey"]!));
        _configuration = configuration;
    }
    public string GetToken(Guid Id)
    {
        var claims = new List<Claim>
        {
            new Claim("UserId", Id.ToString())
        };
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(int.Parse(_configuration["Auth:TokenExpirationDays"]!)),
            SigningCredentials = cred
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateJwtSecurityToken(descriptor);
        return tokenHandler.WriteToken(token);
    }
}
