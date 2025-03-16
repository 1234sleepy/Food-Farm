using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.OrderOperation.Command.AddOrder;

public class AddOrderCommandHandler(IAddOrderStorage orderStorage, IValidator<AddOrderCommand> validator) : IRequestHandler<AddOrderCommand, OrderModel>
{
    private readonly IValidator<AddOrderCommand> _validator = validator;
    private readonly IAddOrderStorage _orderStorage = orderStorage;
    public async Task<OrderModel> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        return await _orderStorage.AddOrder(
            request.Name,
            request.Phone,
            request.Items,
            request.Description,
            request.Email,
            cancellationToken);
    }
}

