using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Label.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Command.AddProduct;

public record class AddProductCommand(string name, decimal price, int quantityLimit,
    string description, decimal discountPrice, List<LabelModel> labels) : IRequest<ProductModel>
{ }
