using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

public interface IGetAllProductsStorage
{
    public IQueryable<ProductModel> GetAllProducts(GetAllProductsQuery query);
}
