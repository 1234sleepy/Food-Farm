using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetProduct;

public interface IGetProductStorage
{
    public Task<ProductModel> GetProduct(Guid id, CancellationToken cancellationToken);
}
