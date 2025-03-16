using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.AdminOperatation.AdminOrderOperation.Base;
using Domain.UseCases.AdminOperatation.AdminOrderOperation.Queries.GetOrder;
using Microsoft.EntityFrameworkCore;

namespace Storage.Storages.Admin.AdminOrderOperation
{
    public class GetOrderStorage(DataContext dataContext, IMapper mapper) : IGetOrderStorage
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;
        public async Task<OrderModel> GetOrder(Guid id, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Orders.ProjectTo<OrderModel>(_mapper.ConfigurationProvider).FirstAsync(x => x.Id == id, cancellationToken);
            return order;
        }
    }

}

