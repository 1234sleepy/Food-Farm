using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public record class AddProductCommand(string name, decimal price, int quantityLimit,
   string description, decimal discountPrice, List<LabelModel> labels) : IRequest<ProductModel>
{ }
