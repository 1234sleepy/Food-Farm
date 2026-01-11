using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public record class AddProductCommand(string Name, decimal Price, int QuantityLimit,
   string Description, decimal DiscountPrice, List<LabelModel> Labels) : IRequest<ProductModel>
{ }
