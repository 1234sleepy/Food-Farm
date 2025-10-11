using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Label.Base;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductModel> AddProduct(
        string name, decimal price, int quantityLimit,
        string description,
        decimal discountPrice, List<LabelModel> labels, CancellationToken cancellationToken);
}
