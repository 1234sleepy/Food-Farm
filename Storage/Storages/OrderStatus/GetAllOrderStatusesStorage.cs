using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.OrderStatusOperation.Base;
using Domain.UseCases.OrderStatusOperation.Queries.GetAllOderStatuses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.OrderStatus
{
    public class GetAllOrderStatusesStorage(DataContext dataContext, IMapper mapper) : IGetAllOrderStatusesStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<List<OrderStatusModel>> GetAllOrderStatuses(CancellationToken cancellationToken)
        {
            var res = await _dataContext.OrderStatus.AsNoTracking().ProjectTo<OrderStatusModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return res;
        }
    }
}
