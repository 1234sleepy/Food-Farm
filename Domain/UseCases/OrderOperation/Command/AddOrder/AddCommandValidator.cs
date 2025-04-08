using FluentValidation;

namespace Domain.UseCases.OrderOperation.Command.AddOrder;

public class AddCommandValidator : AbstractValidator<AddOrderCommand>
{
    public AddCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3)
            .WithErrorCode("Customer name is less than 3 letters");
        RuleFor(x => x.Phone.Length).GreaterThan(9).LessThan(13)
            .WithErrorCode("Phone is not correct");
        RuleFor(x => x.Items).NotNull()
            .WithErrorCode("Quantity can not be zero");
        RuleFor(x => x.Items.Count).GreaterThanOrEqualTo(1)
            .WithErrorCode("Quantity can not be zero");
    }
}
