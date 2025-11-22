using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

public record class UpdateOrderCommand(string Name, string Phone, List<ItemModel> Items, Guid StatusId) : IRequest<OrderModel>
{
    public Guid Id { get; set; }
}
