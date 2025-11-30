namespace Account.MicroService.Domain.UseCases.AccountOperation.LogIn;

public interface ILogInStorage
{
    Task LogIn(LogInCommand command, CancellationToken cancellationToken);
    Task<Guid> GetUserIdByUsername(string username, CancellationToken cancellationToken);
}
