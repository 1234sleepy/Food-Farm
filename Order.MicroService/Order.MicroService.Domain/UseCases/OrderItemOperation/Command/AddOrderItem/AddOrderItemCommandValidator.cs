using FluentValidation;

namespace Order.MicroService.Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidator()
    {
        RuleFor(x => x.quantity).GreaterThan(0)
            .WithErrorCode("Quantity can not be zero");
    }
}
