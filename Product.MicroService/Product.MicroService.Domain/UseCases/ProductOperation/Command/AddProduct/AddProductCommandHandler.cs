using FluentValidation;
using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public class AddProductCommandHandler(
   IAddProductStorage productStorage,
   IValidator<AddProductCommand> validator) : IRequestHandler<AddProductCommand, ProductModel>
{

    private readonly IValidator<AddProductCommand> _validator = validator;
    private readonly IAddProductStorage _productStorage = productStorage;

    public async Task<ProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        return await _productStorage.AddProduct(
            request.name,
            request.price,
            request.quantityLimit,
            request.description,
            request.discountPrice,
            request.labels,
            cancellationToken);
    }
}
