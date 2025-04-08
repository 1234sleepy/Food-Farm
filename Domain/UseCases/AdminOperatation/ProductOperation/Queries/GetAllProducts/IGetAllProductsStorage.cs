using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;

public interface IGetAllProductsStorage
{
    public IQueryable<ProductModel> GetAllProducts(GetAllProductsQuery query);
}
