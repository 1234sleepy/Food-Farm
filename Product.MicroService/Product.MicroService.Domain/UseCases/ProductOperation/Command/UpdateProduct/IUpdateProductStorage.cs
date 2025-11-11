using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.UpdateProduct
{
    public interface IUpdateProductStorage
    {
        public Task<ProductModel> UpdateProduct(
        Guid id, string name, decimal price,
        int quantityLimit, string description,
        bool isVisible, decimal discountPrice, CancellationToken cancellationToken);
    }
}
