using FluentValidation;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.UpdateOrderItem;

public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
{
    public UpdateOrderItemCommandValidator()
    {
        RuleFor(x => x.quantity).GreaterThan(0)
            .WithErrorCode("Quantity can not be zero");
    }
}
