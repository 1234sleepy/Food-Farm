using FluentValidation;
using MediatR;
using Order.MicroService.Domain.UseCases.OrderOperation.Base;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

public class UpdateOrderCommandHandler(IUpdateOrderStorage updateOrderStorage) : IRequestHandler<UpdateOrderCommand, OrderModel>
{
    private readonly IUpdateOrderStorage _updateOrderStorage = updateOrderStorage;
    public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        return await _updateOrderStorage.UpdateOrder(
            request.Id,
            request.Name,
            request.Phone,
            request.Items,
            request.StatusId,
            cancellationToken);
    }
}

