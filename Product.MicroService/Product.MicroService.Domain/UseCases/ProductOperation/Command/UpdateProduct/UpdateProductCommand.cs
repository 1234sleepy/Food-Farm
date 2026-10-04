using MediatR;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

public record class UpdateProductCommand(string Name, decimal Price,
    int QuantityLimit, string Description,
    bool IsVisible, decimal DiscountPrice) : IRequest<ProductEntity>
{
    public Guid Id { get; set; }
}
