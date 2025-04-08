using Domain.UseCases.AdminOperatation.ProductOperation.Command.DeleteProduct;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.ProductOperation;

public class DeleteProductStorage(DataContext dataContext) : IDeleteProductStorage
{
    private readonly DataContext _dataContext = dataContext;
    public async Task DeleteProduct(Guid Id, CancellationToken cancellationToken)
    {
        var product = await _dataContext.Products.FirstAsync(p => p.Id == Id, cancellationToken);
        if (product != null)
        {
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}

