using Domain.UseCases.AdminProductOperation.Base;
using MediatR;
using Storage.Entities;

namespace Domain.UseCases.AdminProductOperation.Command.AddProduct
{
    public record class AddProductCommand(string name,
        decimal price, int quantityLimit, string description,
        bool isVisible, decimal discountPrice, int quantitySold, int totalCommentsQuantity, int totalRating) : IRequest<ProductModel> { } 

}
