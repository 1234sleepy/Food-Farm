using AutoMapper;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Queries.GetOrder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.AdminOrderOperation
{
    public class GetOrderStorage(DataContext dataContext, IMapper mapper) : IGetOrderStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;
        public async Task<OrderModel> GetOrder(Guid id, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return _mapper.Map<OrderModel>(order);
        }
    }
    
}

