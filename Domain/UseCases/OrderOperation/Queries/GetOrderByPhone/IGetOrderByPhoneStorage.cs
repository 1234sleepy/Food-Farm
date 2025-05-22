using Domain.Models;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public interface IGetOrderByPhoneStorage
{
    public IQueryable<OrderModel> GetOrderByPhone(string phone, CancellationToken cancellationToken);
}
