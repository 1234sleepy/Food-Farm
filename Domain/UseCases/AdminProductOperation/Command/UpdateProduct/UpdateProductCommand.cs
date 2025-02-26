using Domain.UseCases.AdminProductOperation.Base;
using MediatR;
using Storage.Entities;

namespace Domain.UseCases.AdminProductOperation.Command.UpdateProduct;

public record class UpdateProductCommand(string name,
        decimal price, int quantityLimit, string description,
        bool isVisible, decimal discountPrice, int quantitySold,
        List<ImageModel> images, int totalCommentsQuantity, int totalRating, List<LabelModel> labels) : IRequest<ProductModel>
{
    public Guid Id { get; set; }
}
