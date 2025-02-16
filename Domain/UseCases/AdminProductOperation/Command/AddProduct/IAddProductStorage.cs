using Domain.Models;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductModel> AddProduct(string name, decimal price, CancellationToken cancellationToken);
}
