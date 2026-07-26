namespace Product.MicroService.Domain.Services.Transaction;

public interface ITransactionService
{
    Task Begin(CancellationToken cancellationToken);
    Task Commit(CancellationToken cancellationToken);
    Task RollBack(CancellationToken cancellationToken);
    Task CreateSavePoint(string name, CancellationToken cancellationToken);
    Task RollbackToSavePoint(string name, CancellationToken cancellationToken);
}
