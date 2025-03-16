using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;

namespace Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public interface IGetOrderByPhoneStorage
{
    public Task<List<OrderModel>> GetOrderByPhone(string phone, CancellationToken cancellationToken);
}
