using Product.MicroService.Domain.Services.Transaction;

namespace Product.MicroService.Storage.Services.Transaction;

public class TransactionService(DataContext dataContext) : ITransactionService
{
    private readonly DataContext _dataContext = dataContext;
    private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction;
    public async Task Begin(CancellationToken cancellationToken)
    {
        transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        if(transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        await transaction.CommitAsync(cancellationToken);
    }

    public async Task RollBack(CancellationToken cancellationToken)
    {
        if (transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        await transaction.RollbackAsync(cancellationToken);
    }
}

//Create Logic for Commit and RollBack methods in TransactionService class.
//Use transaction logic in json parse handler
//record the execution time of JSON product parse api