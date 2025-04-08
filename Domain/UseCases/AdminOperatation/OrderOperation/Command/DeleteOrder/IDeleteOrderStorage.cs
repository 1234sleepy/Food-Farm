namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.DeleteOrder
{
    public interface IDeleteOrderStorage
    {
        Task DeleteOrder(Guid Id, CancellationToken cancellationToken);
    }
}
