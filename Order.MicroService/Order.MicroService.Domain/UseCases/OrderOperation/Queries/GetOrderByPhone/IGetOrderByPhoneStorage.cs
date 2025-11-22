using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public interface IGetOrderByPhoneStorage
{
    public IQueryable<OrderModel> GetOrderByPhone(string phone, CancellationToken cancellationToken);
}
