using Domain.UseCases.AdminOrderOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOrderOperation.Command.AddOrder
{
    public record class AddOrderCommand(Guid id, string name, string phone,
        DateTimeOffset createdAt, List<Guid> itemsId) : IRequest<OrderModel>
    { }


}
