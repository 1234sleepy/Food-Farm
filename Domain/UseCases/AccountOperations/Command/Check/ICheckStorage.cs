namespace Domain.UseCases.AccountOperations.Command.Check;

public interface ICheckStorage
{
    Task<string> Check(Guid UserId, CancellationToken cancellationToken);
}
