using MediatR;
using Product.MicroService.Domain.UseCases.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductsById;

public record class GetProductsByIdQuery(List<string> ids) : IRequest<List<ProductModel>>
{
}
