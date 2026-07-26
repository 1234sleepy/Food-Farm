using Microsoft.EntityFrameworkCore.Storage;
using Product.MicroService.Domain.Services.Transaction;

namespace Product.MicroService.Storage.Services.Transaction;

public class TransactionService(DataContext dataContext) : ITransactionService, IDisposable
{
    private readonly DataContext _dataContext = dataContext;
    private IDbContextTransaction? _transaction;
    public async Task Begin(CancellationToken cancellationToken)
    {
        _transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        if(_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        await _transaction.CommitAsync(cancellationToken);
        _transaction = null;
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }

    public async Task RollBack(CancellationToken cancellationToken)
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        await _transaction.RollbackAsync(cancellationToken);
        _transaction = null;
    }

    public async Task CreateSavePoint(string name, CancellationToken cancellationToken)
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }

        await _transaction.CreateSavepointAsync(name, cancellationToken);
    }

    public async Task RollbackToSavePoint(string name, CancellationToken cancellationToken)
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await _transaction.RollbackToSavepointAsync(name, cancellationToken);
    }
}

//Create Logic for Commit and RollBack methods in TransactionService class.
//Use transaction logic in json parse handler
//record the execution time of JSON product parse api