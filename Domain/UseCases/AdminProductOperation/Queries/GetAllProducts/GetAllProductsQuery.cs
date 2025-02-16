using Domain.Models;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminProductOperation.Queries.GetAllProducts;

public record class GetAllProductsQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<ProductModel>>
{
}
