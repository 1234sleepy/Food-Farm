using FluentValidation;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3)
            .WithErrorCode("Name is less than 3 letters"); ;

        RuleFor(x => x.Price).GreaterThan(0)
            .WithErrorCode("Price can not be zero");
    }
}
