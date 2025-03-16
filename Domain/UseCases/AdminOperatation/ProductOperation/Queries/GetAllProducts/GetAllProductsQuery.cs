using Domain.Models;
using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetAllProducts;

public record class GetAllProductsQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<ProductModel>>
{
}
