using MediatR;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductPriceQuery;

public record class GetProductPriceQuery(Guid Id) : IRequest<decimal>
{
}
