using Domain.Models;
using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using Domain.UseCases.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetAllProducts;

public record class GetAllProductsQuery(string? Sort) : PaginationQuery, IRequest<PaginationList<ProductModel>>
{
}
