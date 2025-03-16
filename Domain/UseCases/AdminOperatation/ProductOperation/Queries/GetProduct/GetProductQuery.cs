using Domain.UseCases.AdminOperatation.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminOperatation.AdminProductOperation.Queries.GetProduct;

public record class GetProductQuery(Guid Id) : IRequest<ProductModel>;
