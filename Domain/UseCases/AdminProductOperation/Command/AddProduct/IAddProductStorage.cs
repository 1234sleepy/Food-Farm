using Domain.UseCases.AdminProductOperation.Base;
using Storage.Entities;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductModel> AddProduct(string name, decimal price, int quantityLimit, string description, bool isVisible, decimal discountPrice, int quantitySold, int totalCommentsQuantity, int totalRating, CancellationToken cancellationToken);
}
