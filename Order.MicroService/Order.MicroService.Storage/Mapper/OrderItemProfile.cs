using AutoMapper;
using Order.MicroService.Domain.UseCases.OrderItemOperation.Base;
using Storage.Entities;

namespace Order.MicroService.Storage.Mapper;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemModel>();
    }
}
