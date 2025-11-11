using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.MicroService.Domain.UseCases.ImageOperation.Command.DeleteImage
{
    public record class DeleteImageCommand(Guid imageId) : IRequest
    {
    }
}
