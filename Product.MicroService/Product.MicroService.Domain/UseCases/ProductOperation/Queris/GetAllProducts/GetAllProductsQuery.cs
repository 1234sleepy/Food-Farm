using MediatR;
using Product.MicroService.Domain.UseCases.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetAllProducts;

public record class GetAllProductsQuery(string? Sort, int minPrice, int MaxPrice) : PaginationQuery, IRequest<PaginationList<ProductModel>>
{
}
