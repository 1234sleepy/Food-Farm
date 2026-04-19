using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductsById;

public interface IGetProductsByIdStorage
{
    public IQueryable<ProductModel> GetProductsById(GetProductsByIdQuery query);
}
