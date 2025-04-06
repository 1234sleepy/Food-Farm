using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Command.AddProduct;

public record class AddProductCommand(string name, decimal price, int quantityLimit,
    string description, decimal discountPrice) : IRequest<ProductModel>
{ }
