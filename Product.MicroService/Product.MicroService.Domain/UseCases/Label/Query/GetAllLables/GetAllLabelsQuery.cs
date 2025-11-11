using MediatR;
using Product.MicroService.Domain.UseCases.Label.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Query.GetAllLables
{
    public record class GetAllLabelsQuery() : IRequest<List<LabelModel>>
    {
    }
}
