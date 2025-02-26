using Domain.UseCases.AdminProductOperation.Base;

namespace Domain.UseCases.AdminProductOperation.Queries.GetProduct;

public interface IGetProductStorage
{
    public Task<ProductModel> GetProduct(Guid id, CancellationToken cancellationToken);
}
