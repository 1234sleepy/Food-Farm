using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;

namespace Domain.UseCases.OrderOperation.Command.AddOrder;

public record class AddOrderCommand(string Name, string Phone, List<ItemModel> Items, string? Description, string? Email) : IRequest<OrderModel>
{
}
