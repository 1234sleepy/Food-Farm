using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductEntity> AddProduct(
    ProductEntity product, CancellationToken cancellationToken);

}
