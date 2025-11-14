using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllUsedLabelByProductId;

public record class GetAllUsedLabelByProductIdQuery(Guid productId) : IRequest<List<LabelModel>>
{
}
