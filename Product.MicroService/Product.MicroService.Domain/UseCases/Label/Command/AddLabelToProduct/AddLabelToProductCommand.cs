using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.AddLabelToProduct
{
    public record class AddLabelToProductCommand(string productId, string labelId) : IRequest
    {
    }
}
