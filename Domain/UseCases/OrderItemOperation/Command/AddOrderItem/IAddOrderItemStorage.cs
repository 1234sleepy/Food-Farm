
using Domain.UseCases.OrderItemOperation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.OrderItemOperation.Command.AddOrderItem;

public interface IAddOrderItemStorage
{
    Task<OrderItemModel> AddOrderItem(
        Guid orderId, Guid productId, int quantity, CancellationToken cancellationToken);
}
