using AutoMapper;
using Domain.UseCases.Label.Command.RemoveLabelFromProduct;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.LabelOperation;

public class RemoveLabelFromProductStorage(DataContext dataContext) : IRemoveLabelFromProductStorage
{
    private readonly DataContext _dataContext = dataContext;

    public async Task RemoveLabelFromProduct(Guid productId, Guid labelId, CancellationToken cancellationToken)
    {
        var label = await _dataContext.ProductLabel.FirstAsync(x => x.LabelId == labelId && x.ProductId == productId, cancellationToken);

        if (label != null)
        {
            _dataContext.ProductLabel.Remove(label);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
