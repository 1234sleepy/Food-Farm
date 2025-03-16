using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;

namespace Domain.UseCases.OrderOperation.Command.AddOrder;

public interface IAddOrderStorage
{
    Task<OrderModel> AddOrder(string name, string phone, List<ItemModel> requests, string? description, string? email, CancellationToken cancellationToken);
}
