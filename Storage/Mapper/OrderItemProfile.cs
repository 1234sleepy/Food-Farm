using AutoMapper;
using Domain.UseCases.AdminOrderOperation.Base;
using Storage.Entities;

namespace Storage.Mapper;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemModel>();
    }
}

