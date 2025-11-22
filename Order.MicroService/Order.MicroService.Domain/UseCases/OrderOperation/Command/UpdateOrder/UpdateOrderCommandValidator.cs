using FluentValidation;

namespace Order.MicroService.Domain.UseCases.OrderOperation.Command.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3)
            .WithErrorCode("Customer name is less than 3 letters");
        RuleFor(x => x.Phone.Length).GreaterThan(9).LessThan(13)
            .WithErrorCode("Phone is not correct");
    }
}
