namespace Domain.UseCases.AdminOperatation.AdminOrderOperation.Command.DeleteOrder
{
    public interface IDeleteOrderStorage
    {
        Task DeleteOrder(Guid Id, CancellationToken cancellationToken);
    }
}
