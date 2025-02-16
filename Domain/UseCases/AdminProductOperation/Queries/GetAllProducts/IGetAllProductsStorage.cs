using Domain.UseCases.AdminProductOperation.Base;

namespace Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;

public interface IGetAllProductsStorage
{
    public IQueryable<ProductModel> GetAllProducts(GetAllProductsQuery query);
}
