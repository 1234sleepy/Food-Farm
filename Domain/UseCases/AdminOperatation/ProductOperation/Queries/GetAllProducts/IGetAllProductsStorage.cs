using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetAllProducts;

public interface IGetAllProductsStorage
{
    public IQueryable<ProductModel> GetAllProducts(GetAllProductsQuery query);
}
