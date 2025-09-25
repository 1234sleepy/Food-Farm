using Domain.UseCases.Label.Base;
using Domain.UseCases.Label.Query.GetAllLabels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Label.Query.GetAllUsedLabelByProductId;

public class GetAllUsedLabelByProductIdQueryHandler(IGetAllUsedLabelByProductIdStorage storage) : IRequestHandler<GetAllUsedLabelByProductIdQuery, List<LabelModel>>
{
    private readonly IGetAllUsedLabelByProductIdStorage _storage = storage;
    public Task<List<LabelModel>> Handle(GetAllUsedLabelByProductIdQuery request, CancellationToken cancellationToken)
    {
        return _storage.GetAllUsedLabels(request.productId, cancellationToken);
    }
}
