using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetAllOrders;

public interface IGetAllOrdersStorage
{
    public IQueryable<OrderModel> GetAllOrder(GetAllOrdersQuery query);
}
