using FluentValidation;
using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProduct;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

public class UpdateProductCommandHandler(

IValidator<UpdateProductCommand> validator,
IUpdateProductStorage updateProduct
) : IRequestHandler<UpdateProductCommand, ProductModel>
{
    private readonly IValidator<UpdateProductCommand> _validator = validator;
    private readonly IUpdateProductStorage _updateProduct = updateProduct;

    public async Task<ProductModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        return await _updateProduct.UpdateProduct(
                request.Id,
                request.name,
                request.price,
                request.quantityLimit,
                request.description,
                request.isVisible,
                request.discountPrice,
                cancellationToken);


    }
}
