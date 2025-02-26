using Domain.UseCases.AdminProductOperation.Base;
using MediatR;

namespace Domain.UseCases.AdminProductOperation.Queries.GetProduct;

public record class GetProductQuery(Guid Id) : IRequest<ProductModel>;
