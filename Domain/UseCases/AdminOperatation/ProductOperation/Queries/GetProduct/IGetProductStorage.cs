using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetProduct;

public interface IGetProductStorage
{
    public Task<ProductModel> GetProduct(Guid id, CancellationToken cancellationToken);
}
