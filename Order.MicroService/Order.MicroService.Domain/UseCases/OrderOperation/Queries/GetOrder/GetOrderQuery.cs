using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrder;

public record class GetOrderQuery(Guid Id) : IRequest<OrderModel>
{
}