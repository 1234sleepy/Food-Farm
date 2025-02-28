using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.OrderItemOperation.Base;
using Domain.UseCases.OrderItemOperation.Queries.GetAllOrderItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Storages.OrderItemsOperation;

public class GetAllOrderItemsStorage(DataContext dataContext, IMapper mapper) : IGetAllOrderItemsStorage
{
    private readonly DataContext _dataContext = dataContext;
    private readonly IMapper _mapper = mapper;
    public IQueryable<OrderItemModel> GetAllOrderItems(GetAllOrderItemsQuery query)
    {
        var take = _dataContext.OrderItems.AsNoTracking();
        take = query.Sort switch
        {
            "productId" => take.OrderBy(x => x.ProductId),
            "orderId" => take.OrderBy(x => x.OrderId),
            _ => take
        };
        return take.ProjectTo<OrderItemModel>(_mapper.ConfigurationProvider);
    }
}
