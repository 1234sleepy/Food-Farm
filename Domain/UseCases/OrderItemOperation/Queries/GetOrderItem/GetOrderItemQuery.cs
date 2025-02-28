using Domain.UseCases.OrderItemOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

public record class GetOrderItemQuery(Guid orderId, Guid productId) : IRequest<OrderItemModel>
{
}
