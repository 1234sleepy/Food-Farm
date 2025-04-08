using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductModel> AddProduct(
        string name, decimal price, int quantityLimit,
        string description,
        decimal discountPrice, CancellationToken cancellationToken);
}
