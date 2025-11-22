using MediatR;
using Order.MicroService.Domain.UseCases.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetAllOrders;

public record class GetAllOrdersQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<OrderModel>>
{
}
