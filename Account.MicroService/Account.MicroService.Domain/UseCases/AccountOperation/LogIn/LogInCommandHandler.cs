using Account.MicroService.Domain.Models;
using MediatR;

namespace Account.MicroService.Domain.UseCases.AccountOperation.LogIn;

public class LogInCommandHandler(ILogInStorage logInStorage) : IRequestHandler<LogInCommand, UserModel>
{
    private readonly ILogInStorage _logInStorage = logInStorage;

    public async Task<UserModel> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        await _logInStorage.LogIn(request, cancellationToken);

        return await _logInStorage.GetUserByUsername(request.username, cancellationToken);
    }
}
