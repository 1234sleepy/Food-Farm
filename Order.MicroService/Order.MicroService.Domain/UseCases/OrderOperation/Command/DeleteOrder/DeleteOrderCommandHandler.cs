using FluentValidation;
using MediatR;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.DeleteOrder;

public class DeleteOrderCommandHandler(IDeleteOrderStorage deleteOrder, IValidator<DeleteOrderCommand> validator) : IRequestHandler<DeleteOrderCommand>
{
    private readonly IValidator<DeleteOrderCommand> _validatror = validator;
    private readonly IDeleteOrderStorage _deleteOrder = deleteOrder;
    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await _validatror.ValidateAsync(request, cancellationToken);
        await _deleteOrder.DeleteOrder(request.id, cancellationToken);
    }
}
