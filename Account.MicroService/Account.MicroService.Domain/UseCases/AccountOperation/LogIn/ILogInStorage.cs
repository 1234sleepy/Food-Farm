using Account.MicroService.Domain.Models;

namespace Account.MicroService.Domain.UseCases.AccountOperation.LogIn;

public interface ILogInStorage
{
    Task LogIn(LogInCommand command, CancellationToken cancellationToken);
    Task<UserModel> GetUserByUsername(string username, CancellationToken cancellationToken);
}
