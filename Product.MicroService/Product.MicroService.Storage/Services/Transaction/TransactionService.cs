using Product.MicroService.Domain.Services.Transaction;

namespace Product.MicroService.Storage.Services.Transaction;

public class TransactionService(DataContext dataContext) : ITransactionService
{
    private readonly DataContext _dataContext = dataContext;

    public async Task Begin(CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        
    }

    public async Task RollBack(CancellationToken cancellationToken)
    {
        
    }
}

//Create Logic for Commit and RollBack methods in TransactionService class.
//Use transaction logic in json parse handler
//record the execution time of JSON product parse api