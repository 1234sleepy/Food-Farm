using Domain.Models;

namespace Domain.UseCases.AccountOperations.Command.LogIn;

public interface ILogInStorage
{
    Task LogIn(LogInCommand command, CancellationToken cancellationToken);

    Task<Guid> GetUserIdByUsername(string username, CancellationToken cancellationToken);
}
