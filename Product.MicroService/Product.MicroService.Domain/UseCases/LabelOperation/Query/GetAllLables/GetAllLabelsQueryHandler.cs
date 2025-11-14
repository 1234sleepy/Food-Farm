using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Base;

namespace Product.MicroService.Domain.UseCases.LabelOperation.Query.GetAllLables;

internal class GetAllLabelsQueryHandler(IGetAllLabelsStorage storage) : IRequestHandler<GetAllLabelsQuery, List<LabelModel>>
{
    private readonly IGetAllLabelsStorage _storage = storage;

    public Task<List<LabelModel>> Handle(GetAllLabelsQuery request, CancellationToken cancellationToken)
    {
        return _storage.GetAllLabels(cancellationToken);
    }
}
