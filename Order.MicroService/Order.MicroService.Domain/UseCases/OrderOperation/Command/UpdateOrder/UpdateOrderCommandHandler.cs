using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

public class UpdateOrderCommandHandler(IUpdateOrderStorage updateOrderStorage, IValidator<UpdateOrderCommand> validator) : IRequestHandler<UpdateOrderCommand, OrderModel>
{
    private readonly IUpdateOrderStorage _updateOrderStorage = updateOrderStorage;
    private readonly IValidator<UpdateOrderCommand> _validator = validator;
    public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        return await _updateOrderStorage.UpdateOrder(
            request.Id,
            request.Name,
            request.Phone,
            request.Items,
            request.StatusId,
            cancellationToken);
    }
}

