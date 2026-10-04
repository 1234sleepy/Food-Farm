using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct;

public interface IUpdateProductStorage
{
    public Task<ProductEntity> UpdateProduct(
    ProductEntity product, CancellationToken cancellationToken);
}
