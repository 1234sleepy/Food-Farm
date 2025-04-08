using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public record class GetOrderByPhoneQuery(string Phone) : IRequest<List<OrderModel>>
{
}
