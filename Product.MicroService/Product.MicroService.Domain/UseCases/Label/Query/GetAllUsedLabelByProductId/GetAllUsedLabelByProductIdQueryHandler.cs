using MediatR;
using Product.MicroService.Domain.UseCases.Label.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Query.GetAllUsedLabelByProductId
{
    public class GetAllUsedLabelByProductIdQueryHandler(IGetAllUsedLabelByProductIdStorage storage) : IRequestHandler<GetAllUsedLabelByProductIdQuery, List<LabelModel>>
    {
        private readonly IGetAllUsedLabelByProductIdStorage _storage = storage;
        public Task<List<LabelModel>> Handle(GetAllUsedLabelByProductIdQuery request, CancellationToken cancellationToken)
        {
            return _storage.GetAllUsedLabels(request.productId, cancellationToken);
        }
    }

}
