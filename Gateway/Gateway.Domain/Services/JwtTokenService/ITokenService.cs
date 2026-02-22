namespace Gateway.Domain.Services.JwtTokenService;

public interface ITokenService
{
    string GetToken(Guid id, string userName, List<string> roles);
}

