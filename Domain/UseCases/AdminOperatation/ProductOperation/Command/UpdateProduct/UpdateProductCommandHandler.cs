using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetProduct;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.UpdateProduct;

public class UpdateProductCommandHandler(
    IValidator<UpdateProductCommand> validator,
    IUpdateProductStorage updateProduct,
    IGetProductStorage getProductStorage
    ) : IRequestHandler<UpdateProductCommand, ProductModel>
{
    private readonly IValidator<UpdateProductCommand> _validator = validator;
    private readonly IUpdateProductStorage _updateProduct = updateProduct;
    private readonly IGetProductStorage _getProductStorage = getProductStorage;

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
