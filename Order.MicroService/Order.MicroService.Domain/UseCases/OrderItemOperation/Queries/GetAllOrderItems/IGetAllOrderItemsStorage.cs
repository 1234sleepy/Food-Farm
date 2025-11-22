using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;

public interface IGetAllOrderItemsStorage
{
    public IQueryable<OrderItemModel> GetAllOrderItems(GetAllOrderItemsQuery query);
}
