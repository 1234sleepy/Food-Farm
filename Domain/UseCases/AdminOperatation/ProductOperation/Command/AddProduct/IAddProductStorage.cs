using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductModel> AddProduct(
        string name, decimal price, int quantityLimit,
        string description,
        decimal discountPrice, CancellationToken cancellationToken);
}
