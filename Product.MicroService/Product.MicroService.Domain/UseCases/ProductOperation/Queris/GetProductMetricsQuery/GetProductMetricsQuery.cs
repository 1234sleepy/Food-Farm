using MediatR;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Queris.GetProductMetricsQuery;

public record class GetProductMetricsQuery(Guid Id) : IRequest<ProductMetricsModel>
{
}
