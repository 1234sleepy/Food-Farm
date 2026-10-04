using FluentValidation;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3)
            .WithErrorCode("Name is less than 3 letters"); ;

        RuleFor(x => x.Price).GreaterThan(0)
            .WithErrorCode("Price can not be zero");
    }
}
