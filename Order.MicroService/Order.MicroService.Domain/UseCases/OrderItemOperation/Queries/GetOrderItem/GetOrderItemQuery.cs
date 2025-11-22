using MediatR;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Queries.GetOrderItem;

public record class GetOrderItemQuery(Guid orderId, Guid productId) : IRequest<OrderItemModel>
{
}
