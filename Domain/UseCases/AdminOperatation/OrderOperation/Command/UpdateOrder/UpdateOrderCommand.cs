using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOperatation.OrderOperation.Command.UpdateOrder
{
    public record class UpdateOrderCommand(string Name, string Phone, List<ItemModel> Items, Guid StatusId): IRequest<OrderModel>
    {
        public Guid Id { get; set; }
    }
}
