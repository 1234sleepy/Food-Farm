using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrder;

public interface IGetOrderStorage
{
    public Task<OrderModel> GetOrder(Guid id, CancellationToken cancellationToken);
}
