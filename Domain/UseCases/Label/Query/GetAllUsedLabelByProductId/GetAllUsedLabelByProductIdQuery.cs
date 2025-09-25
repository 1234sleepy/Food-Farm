using Domain.UseCases.Label.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Label.Query.GetAllUsedLabelByProductId;

public record class GetAllUsedLabelByProductIdQuery(Guid productId) : IRequest<List<LabelModel>>
{
}
