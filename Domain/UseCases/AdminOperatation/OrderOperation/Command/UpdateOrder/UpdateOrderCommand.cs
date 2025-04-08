using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder
{
    public record class UpdateOrderCommand(Guid id, string name, string phone, DateTimeOffset createdAt, List<Guid> itemsId, CancellationToken cancellationToken): IRequest<OrderModel>
    {
        public Guid Id { get; set; }
    }
}
