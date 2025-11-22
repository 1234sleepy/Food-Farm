using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.AddOrder;

public record class AddOrderCommand(string Name, string Phone, List<ItemModel> Items, string? Description, string? Email) : IRequest<OrderModel>
{
}
