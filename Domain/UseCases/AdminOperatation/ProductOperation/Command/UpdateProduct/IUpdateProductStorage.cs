using Domain.UseCases.AdminOperatation.ProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.UpdateProduct;

public interface IUpdateProductStorage
{
    public Task<ProductModel> UpdateProduct(
        Guid id, string name, decimal price,
        int quantityLimit, string description,
        bool isVisible, decimal discountPrice, CancellationToken cancellationToken);
}
