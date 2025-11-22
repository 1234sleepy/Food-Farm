using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

public interface IUpdateOrderStorage
{
    public Task<OrderModel> UpdateOrder(Guid id, string name, string phone, List<ItemModel> Items, Guid StatusId, CancellationToken cancellationToken);
}
