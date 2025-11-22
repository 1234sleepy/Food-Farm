using Domain.UseCases.OrderItemOperation.Base;


namespace Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems
{
    public interface IGetAllOrderItemsStorage
    {
        public IQueryable<OrderItemModel> GetAllOrderItems(GetAllOrderItemsQuery query);
    }
}
