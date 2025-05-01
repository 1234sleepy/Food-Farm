using Domain.Models;
using Domain.Services.JwtTokenService;
using MediatR;

namespace Domain.UseCases.AccountOperations.Command.LogIn;

public class LogInCommandHandler(ILogInStorage logInStorage, ITokenService tokenService) : IRequestHandler<LogInCommand, UserModel>
{
    private readonly ILogInStorage _logInStorage = logInStorage;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<UserModel> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        await _logInStorage.LogIn(request, cancellationToken);
        var userId = await _logInStorage.GetUserIdByUsername(request.username, cancellationToken);

        return new UserModel { Token = _tokenService.GetToken(userId) } ;
    }
}
