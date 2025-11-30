using FluentValidation;
using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public class AddProductCommandHandler(IAddProductStorage productStorage) : IRequestHandler<AddProductCommand, ProductModel>
{

    private readonly IAddProductStorage _productStorage = productStorage;

    public async Task<ProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
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
