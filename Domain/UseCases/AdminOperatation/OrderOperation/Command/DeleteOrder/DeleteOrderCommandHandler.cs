using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler(IDeleteOrderStorage deleteOrder): IRequestHandler<DeleteOrderCommand>
    {
        private readonly IDeleteOrderStorage _deleteOrder = deleteOrder;
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _deleteOrder.DeleteOrder(request.Id, cancellationToken);
        }
    }
    
}

