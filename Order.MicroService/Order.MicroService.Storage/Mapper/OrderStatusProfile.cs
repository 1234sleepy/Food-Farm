using AutoMapper;
using Order.MicroService.Domain.UseCases.OrderStatusOperation.Base;
using Storage.Entities;

namespace Order.MicroService.Storage.Mapper;

public class OrderStatusProfile : Profile
{
    public OrderStatusProfile()
    {
        CreateMap<OrderStatus, OrderStatusModel>();
    }
}
