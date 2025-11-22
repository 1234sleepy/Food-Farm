using MediatR;
using Order.MicroService.Domain.UseCases.Base;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems
{
    public record class GetAllOrderItemsQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<OrderItemModel>>
    {
    }
}
