using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public interface IAddProductStorage
{
    Task<ProductModel> AddProduct(
   string name, decimal price, int quantityLimit,
   string description,
   decimal discountPrice, List<LabelModel> labels, CancellationToken cancellationToken);

    Task<ProductModel> AddProduct(
string name, decimal price, int quantityLimit,
string description,
decimal discountPrice, CancellationToken cancellationToken);

    Task<ProductModel> AddProductSimple(
string name, decimal price, int quantityLimit,
string description,
decimal discountPrice, CancellationToken cancellationToken);
}
