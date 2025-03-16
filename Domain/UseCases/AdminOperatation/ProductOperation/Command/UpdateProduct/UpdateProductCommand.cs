using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.UpdateProduct;

public record class UpdateProductCommand(string name,
        decimal price, int quantityLimit, string description,
        bool isVisible, decimal discountPrice, int quantitySold,
        List<Guid> imagesId, int totalCommentsQuantity, int totalRating, List<Guid> labelsId) : IRequest<ProductModel>
{
    public Guid Id { get; set; }
}
