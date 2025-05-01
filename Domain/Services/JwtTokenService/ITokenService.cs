using Domain.Models;

namespace Domain.Services.JwtTokenService;

public interface ITokenService
{
    string GetToken(Guid Id);
}
