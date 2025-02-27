using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOrderOperation.Base;
using Domain.UseCases.AdminOrderOperation.Queries.GetAllOrder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.AdminOrderOperation
{
    public class GetAllOrdersStorage(DataContext dataContext, IMapper mapper) : IGetAllOrdersStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public IQueryable<OrderModel> GetAllOrder(GetAllOrdersQuery query)
        {
            var take = _dataContext.Orders.AsNoTracking();

            take = query.Sort switch
            {
                "id" => take.OrderBy(x => x.Id),
                "name" => take.OrderBy(x => x.Name),
                "price" => take.OrderBy(x => x.Phone),
                _ => take
            };

            return take.ProjectTo<OrderModel>(_mapper.ConfigurationProvider);
        }
    }
}
