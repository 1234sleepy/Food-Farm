namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.DeleteOrder;

public interface IDeleteOrderStorage
{
    Task DeleteOrder(Guid Id, CancellationToken cancellationToken);
}
