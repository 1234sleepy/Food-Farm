namespace Account.MicroService.Domain.Services.JwtTokenService;

public interface ITokenService
{
    string GetToken(Guid Id);
}
