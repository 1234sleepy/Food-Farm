﻿using Domain.UseCases.AdminOperatation.OrderOperation.Command.DeleteOrder;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.OrderOperation
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
