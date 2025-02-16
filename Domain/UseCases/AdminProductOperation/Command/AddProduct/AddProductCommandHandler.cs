using Domain.Models;
using FluentValidation;
using MediatR;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct
{
    public class AddProductCommandHandler(
        IAddProductStorage productStorage,
        IValidator<AddProductCommand> validator) : IRequestHandler<AddProductCommand, ProductModel>
    {

        private readonly IValidator<AddProductCommand> _validator = validator;
        private readonly IAddProductStorage _productStorage = productStorage;

        public async Task<ProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            return await _productStorage.AddProduct(
                request.Name,
                request.Price,
                cancellationToken);
        }
    }
}
