using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public required Guid Id { get; set; }
    }   
}
