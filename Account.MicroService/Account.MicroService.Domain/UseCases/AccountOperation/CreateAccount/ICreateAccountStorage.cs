namespace Account.MicroService.Domain.UseCases.AccountOperation.CreateAccount;

public interface ICreateAccountStorage
{
    public Task CreateAccount(string userName, string password, string email, string role, CancellationToken cancellationToken);
}

