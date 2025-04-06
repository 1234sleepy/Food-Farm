using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.UpdateProduct;

public interface IUpdateProductStorage
{
    public Task<ProductModel> UpdateProduct(
        Guid id, string name, decimal price,
        int quantityLimit, string description,
        bool isVisible, decimal discountPrice, CancellationToken cancellationToken);
}
