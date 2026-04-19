using FoodFarm.Account.MicroService.API.Grpc;
using Gateway.Domain.Models;
using Gateway.Domain.Services.JwtTokenService;
using MediatR;

namespace Gateway.Domain.UseCases.AuthOperation.LogIn;

public class LogInCommandHandler(ITokenService tokenService, AccountEngine.AccountEngineClient client) : IRequestHandler<LogInCommand, UserModel>
{
    private readonly ITokenService _tokenService = tokenService;
    private readonly AccountEngine.AccountEngineClient _client = client;

    public async Task<UserModel> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        var res = await _client.LogInAsync(new LogInRequest 
        {
            Username = request.username,
            Password = request.password
        },
        cancellationToken:cancellationToken);

        return new UserModel()
        {
            Id = Guid.Parse(res.Id),
            Token = _tokenService.GetToken(Guid.Parse(res.Id), res.Username, res.Roles.ToList()),
            UserName = res.Username,
            Email = res.Email,
        }; 
    }
}