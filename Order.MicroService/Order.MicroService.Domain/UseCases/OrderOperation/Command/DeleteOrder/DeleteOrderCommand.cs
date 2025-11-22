using MediatR;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.DeleteOrder;

public record class DeleteOrderCommand(Guid id) : IRequest { }

