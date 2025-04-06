using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.UpdateProduct;

public record class UpdateProductCommand(string name, decimal price,
        int quantityLimit, string description,
        bool isVisible, decimal discountPrice, CancellationToken cancellationToken) : IRequest<ProductModel>
{
    public Guid Id { get; set; }
}
