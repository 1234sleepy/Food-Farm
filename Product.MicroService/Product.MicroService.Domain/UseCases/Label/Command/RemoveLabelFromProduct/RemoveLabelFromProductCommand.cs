using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.Label.Command.RemoveLabelFromProduct
{
    public record class RemoveLabelFromProductCommand(Guid productId, Guid labelId) : IRequest
    {
    }
}
