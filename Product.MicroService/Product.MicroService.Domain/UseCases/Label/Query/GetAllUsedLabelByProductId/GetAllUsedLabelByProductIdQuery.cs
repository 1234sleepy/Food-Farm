using MediatR;
using Product.MicroService.Domain.UseCases.Label.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Query.GetAllUsedLabelByProductId
{
    public record class GetAllUsedLabelByProductIdQuery(Guid productId) : IRequest<List<LabelModel>>
    {
    }
}
