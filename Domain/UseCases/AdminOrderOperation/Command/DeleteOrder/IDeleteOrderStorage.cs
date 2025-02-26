namespace Domain.UseCases.AdminOrderOperation.Command.DeleteOrder
{
    public interface IDeleteOrderStorage
    {
        Task DeleteOrder(Guid Id, CancellationToken cancellationToken);
    }
}
