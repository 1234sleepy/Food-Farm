using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gateway.Domain.Services.JwtTokenService;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey key;
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:TokenKey"]!));
        _configuration = configuration;
    }
    public string GetToken(Guid id, string userName, List<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Name, userName)
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

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
