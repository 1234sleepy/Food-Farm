using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllUsedLabelByProductId;

public class GetAllUsedLabelByProductIdQueryHandler(IGetAllUsedLabelByProductIdStorage storage) : IRequestHandler<GetAllUsedLabelByProductIdQuery, List<LabelModel>>
{
    private readonly IGetAllUsedLabelByProductIdStorage _storage = storage;
    public Task<List<LabelModel>> Handle(GetAllUsedLabelByProductIdQuery request, CancellationToken cancellationToken)
    {
        return _storage.GetAllUsedLabels(request.productId, cancellationToken);
    }
}
