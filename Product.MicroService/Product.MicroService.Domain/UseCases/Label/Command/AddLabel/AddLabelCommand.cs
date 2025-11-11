using MediatR;
using Product.MicroService.Domain.UseCases.Label.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.AddLabel
{
    public record class AddLabelCommand(string name, string color) : IRequest<LabelModel>
    {
    }
}
