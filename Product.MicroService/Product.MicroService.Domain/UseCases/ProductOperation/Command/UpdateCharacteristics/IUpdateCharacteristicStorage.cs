namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateCharacterisitc;

public interface IUpdateCharacteristicStorage
{
    Task UpdateCharacteristic(Guid id, string json, CancellationToken cancellationToken);
}
