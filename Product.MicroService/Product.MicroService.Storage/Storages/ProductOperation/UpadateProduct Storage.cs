using Microsoft.EntityFrameworkCore;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateCharacterisitc;

namespace Product.MicroService.Storage.Storages.ProductOperation;

public class UpdateCharacteristicStorage(DataContext dataContext) : IUpdateCharacteristicStorage
{
    private readonly DataContext _dataContext = dataContext;
    public async Task UpdateCharacteristic(Guid id, string json, CancellationToken cancellationToken)
    {

        await _dataContext.Products.Where(x => x.Id == id).ExecuteUpdateAsync(p => p
            .SetProperty(x => x.Characteristics, json), cancellationToken);
    }
}
