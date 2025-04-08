using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.OrderOperation.Base;
using Domain.UseCases.AdminOperatation.OrderOperation.Queries.GetAllOrders;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.OrderOperation
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
