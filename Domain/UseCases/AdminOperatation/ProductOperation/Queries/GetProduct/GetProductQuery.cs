using Domain.UseCases.AdminOperatation.ProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.ProductOperation.Queries.GetProduct;

public record class GetProductQuery(Guid Id) : IRequest<ProductModel>;
