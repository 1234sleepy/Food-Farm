using Domain.Models;
using Domain.UseCases.Base;
using Domain.UseCases.OrderItemOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;

public record class GetAllOrderItemsQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<OrderItemModel>>
{
}
