namespace Domain.UseCases.AccountOperations.Command.CreateAccount;

public interface ICreateAccountStorage
{
    public Task CreateAccount(string userName, string password, string email, string role, CancellationToken cancellationToken);
}
