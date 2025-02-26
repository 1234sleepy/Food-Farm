using Domain.UseCases.AdminOrderOperation.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Command.AddOrder
{
    public record class AddOrderCommand(Guid id, string name, int phone, 
        DateTimeOffset createdAt, List<OrderItemModel> Items) : IRequest<OrderModel>{ }


}
