namespace Domain.UseCases.OrderItemOperation.Command.DeleteOrderItem;

public interface IDeleteOrderItemStorage
{
    Task DeleteOrderItem(Guid OrderId, Guid ProductId, CancellationToken cancellationToken);
}
