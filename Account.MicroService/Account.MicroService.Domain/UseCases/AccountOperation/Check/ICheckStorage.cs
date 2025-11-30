namespace Account.MicroService.Domain.UseCases.AccountOperation.Check;

public interface ICheckStorage
{
    Task<string> Check(Guid UserId, CancellationToken cancellationToken);
}
