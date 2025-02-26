using Domain.UseCases.AdminProductOperation.Base;
using Storage.Entities;

namespace Domain.UseCases.AdminProductOperation.Command.UpdateProduct;

public interface IUpdateProductStorage
{
    public Task<ProductModel> UpdateProduct(Guid id, string name,
        decimal price, int quantityLimit, string description,
        bool isVisible, decimal discountPrice, int quantitySold,
        List<ImageModel> Images, int totalCommentsQuantity, int totalRating, List<LabelModel> Labels, CancellationToken cancellationToken);
}
