using Domain.UseCases.OrderItemOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Base
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Phone { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public List<OrderItemModel>? Items { get; set; }
    }
}
