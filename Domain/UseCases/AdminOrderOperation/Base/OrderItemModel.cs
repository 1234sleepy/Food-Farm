using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.AdminOrderOperation.Base
{
    public class OrderItemModel
    {
        public Guid OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public int Quantity { get; set; }
    }
}
