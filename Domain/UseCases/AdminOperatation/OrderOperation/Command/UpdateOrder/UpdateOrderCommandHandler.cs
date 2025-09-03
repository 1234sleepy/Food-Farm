using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetOrder;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler(IUpdateOrderStorage updateOrderStorage, IValidator<UpdateOrderCommand> validator) : IRequestHandler<UpdateOrderCommand, OrderModel>
    {
        private readonly IUpdateOrderStorage _updateOrderStorage = updateOrderStorage;
        private readonly IValidator<UpdateOrderCommand> _validator = validator;
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

}

