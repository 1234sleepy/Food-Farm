using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.DeleteOrder
{
    public record class DeleteOrderCommand(Guid id) : IRequest { }
 
}
