using AutoMapper;
using Domain.UseCases.OrderItemOperation.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemModel>();
    }
}

