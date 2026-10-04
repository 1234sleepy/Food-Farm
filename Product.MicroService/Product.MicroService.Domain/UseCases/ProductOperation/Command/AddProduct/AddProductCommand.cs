using MediatR;
using Product.MicroService.Domain.Entities;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;

public record AddProductCommand(string Name, decimal Price, int QuantityLimit,
   string Description, decimal DiscountPrice, List<LabelModel> Labels) : IRequest<ProductEntity>
{ }
