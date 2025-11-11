using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct
{
    public record class UpdateProductCommand(string name, decimal price,
        int quantityLimit, string description,
        bool isVisible, decimal discountPrice, CancellationToken cancellationToken) : IRequest<ProductModel>
    {
        public Guid Id { get; set; }
    }
}
