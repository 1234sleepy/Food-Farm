using MediatR;
using Order.MicroService.Domain.UseCases.Base;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Queries.GetOrderByPhone;

public record class GetOrderByPhoneQuery(string Phone) : PaginationQuery, IRequest<PaginationList<OrderModel>>
{
}
