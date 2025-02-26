using Domain.UseCases.AdminOrderOperation.Command.DeleteOrder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.AdminOrderOperation
{
    public class DeleteOrderStorage(DataContext dataContext) : IDeleteOrderStorage
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task DeleteOrder(Guid Id, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Orders.FirstAsync(p => p.Id == Id, cancellationToken);
            if (order != null)
            {
                _dataContext.Orders.Remove(order);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
